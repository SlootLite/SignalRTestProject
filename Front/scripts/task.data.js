class TaskRepository {
    get(onSuccess){
        $.get(url + "task", null, onSuccess, "json");
    }
}