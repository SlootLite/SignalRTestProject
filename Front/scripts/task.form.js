class TaskForm {
    init(table, hubNotify, hubLoading) {
        $("#task-form").submit(function (event) {
            event.preventDefault();
            var value = $("#taskName").val();
            if (value.length <= 0) {
                alert("Должно быть введено значение");
                return;
            }
            $("#taskName").val("");

            hubLoading.invoke('Send', {
                taskName: value,
                notifyConnectionId: hubNotify.connectionId
            });
        });
    }
}