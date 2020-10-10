const hubLoading = createHub(url + "loading");
const hubNotify = createHub(url + "notify");

var repo = new TaskRepository();
var form = new TaskForm();
var notify = new TaskNotify();
$(document).ready(function(){
	var table = new TaskTable();
	form.init(table, hubNotify, hubLoading);
	repo.get(function(data){
		console.log(data);
		for(var i = 0; i < data.length; i++){
			table.add(data[i]);
		}
	});
	initLoading(table);
	initNotify(notify);
});
function initLoading(table){
	hubLoading.on("Send", function (data) {
		var elem = $("#" + data.id);
		if(elem.length > 0)
			table.update(data);
		else 
			table.add(data);
	});
	hubLoading.start();
}
function initNotify(notify) {
	hubNotify.on("Notify", function (data) {
		notify.add(data);
	});
	hubNotify.start();
}
