class TaskNotify {
    add(textNotify) {
        var notify = $("<div>", {
            "class": "alert alert-dark",
            text: textNotify,
            style: "display: none"
        });
        $("#notify-block").append(notify.attr( {
            "role": "alert"
        }).fadeIn(300));
        setTimeout(function () {
            notify.fadeOut(300, function(){
                notify.remove();
            });
        }, 10000);
    }
}