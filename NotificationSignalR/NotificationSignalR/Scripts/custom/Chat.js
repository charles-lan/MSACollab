 $(function () {

     var chat = $.connection.notifHub;

     chat.client.receiveNotification = function (message) {
         $("#popUpContainer").html(message);
         $("#popUpContainer").slideDown(2000);
         setTimeout('$("#popUpContainer").slideUp(2000);', 2000);
     };

     chat.client.addNewMessageToPage = function (groupname, message) {
         $('#notiflist').append('<li><strong>' + htmlEncode(groupname)
             + '</strong>: ' + htmlEncode(message) + '</li>');
     };

     chat.client.addUserToGroup = function (groupname, userid) {
         if (groupname == "g1") {
             $('#group1list').append('<li>' + userid + '</li>');
         } else if (groupname == "g2") {
             $('#group2list').append('<li>' + userid + '</li>');
         } else if (groupname == "g3") {
             $('#group3list').append('<li>' + userid + '</li>');
         } else {
             console.log("invalid groupname : " + groupname);
         }
     }

     $('#message').focus();
     $.connection.hub.start().done(function () {
         $('#sendmessage').click(function () {
             chat.server.send($('#groupselected').val(), $('#message').val());
             
             var newtr = document.createElement('tr');
             var newtd = document.createElement('td');

             newtd = $('#groupselected').val();
             newtr.appendChild(newtd);
             newtd = $('#message').val();
             newtr.appendChild(newtd);
             $('#notiftable').append(newtr);

             chat.server.sendNotifications($('#groupselected').val(), "New Message:" + $('#message').val());
             $('#message').val('').focus();
         });

         $("input[type='radio'][name='grouprad']").click(function () {
             var selectedgroup = $("input[type='radio'][name='grouprad']:checked");
             if (selectedgroup.length > 0) {
                 selectedgroup = selectedgroup.val();
                 chat.server.joinGroup(selectedgroup);
             }
         });
     });
 });

 function htmlEncode(value) {
     var encodedValue = $('<div />').text(value).html();
     return encodedValue;
 }