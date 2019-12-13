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
    })
})

