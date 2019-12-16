$(document).ready(function() {
    var arrow = $(".arrow");
    var form = $(".login-form");
    var status = false;
    $(".login").click(function(event) {
        event.preventDefault();
        if(status === false) {
            arrow.toggle();
            form.toggle();
            status = true;
        } else {
            arrow.toggle();
            form.toggle();
            status = false;
        }
    });
});


$(function () {

    $('input[name="command"]').click(function () {
        // because there is a command button on each row it is important to
        // retrieve the id that is in the same row as the button
        $('#UserId').val($(this).parents('tr:first').children('td:first').html());

    });

});

function DeleteUser(user) {
    var deleteUser = {
        UserId: $(user).val()
    };

    $.ajax({
        type: "POST",
        url: "Admin",
        content: "application/json; charset=utf-8",
        dataType: "json",
        data: deleteUser,
        success: function (returned) {
            //if (returned === "success") {
            //    swal("Success", "You successfully deleted the coin", "success");
            //} else {
            //    swal("Error", "Could not delete", "error");
            //}
        },
        error: function (xhr, textStatus, errorThrown) {
            alert(xhr + " " + textStatus + " " + errorThrown);
        }
    });
}



function DeleteRow(userId) {
    var deleteId = "#userRow-";
    var fullDeleteId = deleteId.concat(userId);

    $(fullDeleteId).remove();

    DeleteUser(userId);
}

