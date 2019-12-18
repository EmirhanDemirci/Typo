$(document).ready(function () {
    $('#sidebar-btn').click(function () {
        $('#sidebar').toggleClass('visible');
    });
});

$(document).ready(function () {
    var form = $(".login-form");
    var status = false;
    $("#login").click(function (event) {
        event.preventDefault();
        if (status === false) {
            form.toggle();
            status = true;
        } else {
            form.toggle();
            status = false;
        }
    })
})

