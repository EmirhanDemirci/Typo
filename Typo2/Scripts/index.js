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

function DeleteUser(user) {
    var coinId = "#delete-";
    var fullCoinId = coinId.concat(user);
    var deleteUser = {
        UserId: $(fullCoinId).val()

    };
    if (returned === "success") {
        Swal.fire(
            'Good job!',
            'You clicked the button!',
            'success'
        );

    } else {
        Swal.fire(
            'Good job!',
            'You clicked the button!',
            'success'
        );
    }
    $.ajax({
        type: "POST",
        url: "Admin",
        content: "application/json; charset=utf-8",
        dataType: "json",
        data: deleteUser,
        success: function (returned) {
            
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

