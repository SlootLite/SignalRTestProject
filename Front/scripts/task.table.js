class TaskTable {
    constructor() {
        this._table = jQuery("#task-table").children("tbody");
    }
    add(data) {
        this._table.append($("<tr>", {
            id: data.id,
            append: [
                $("<td>", {
                    text: data.name,
                }),
                $("<td>", {
                    text: data.statusText,
                }),
                $("<td>", {
                    append: $("<div>", {
                        "class":"progress",
                        append: $("<div>", {
                            "class":"progress-bar",
                            text: data.percentComplete + "%",
                            style: "width: " + data.percentComplete+"%;"
                        }).attr({
                            "role": "progressbar",
                            "aria-valuenow": "progressbar",
                            "aria-valuemin": data.percentComplete,
                            "aria-valuemax": "100",
                        })
                    })
                })
            ]
        }));
    }
    update(data) {
        var nameTd = $("#" + data.id).find("td:eq(0)"),
            statusTd = $("#" + data.id).find("td:eq(1)"),
            loader = $("#" + data.id).find("td:eq(2) .progress .progress-bar");
            
        nameTd.text(data.name);
        statusTd.text(data.statusText);
        loader.text(data.percentComplete + "%");
        loader.attr({
            style: "width: " + data.percentComplete + "%;",
            "aria-valuemin": data.percentComplete
        });
    }
}