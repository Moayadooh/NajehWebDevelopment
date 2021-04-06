$(function () {

    //Display all countries
    function Display() {
        $.ajax({
            url: "https://localhost:44399/api/Countries",
            type: "GET",
            contentType: "application/json ; charset=utf-8",
            dataType: "JSON",
            success: function (data) {
                var table = "<table class='table table-hover' style='background:white;'>";
                table += "<tr><th>Country Name</th>";
                table += "<th>Country Continent</th>";
                table += "<th>Edit</th>";
                table += "<th>Delete</th></tr>";
                for (var i = 0; i < data.length; i++) {
                    table += "<tr>";
                    table += "<td>" + data[i].name + "</td>";
                    table += "<td>" + data[i].continent + "</td>";
                    table += "<td><i class='fas fa-edit' value=" + data[i].id + "></i></td>";
                    table += "<td><i class='fas fa-trash-alt' value=" + data[i].id + "></i></td>";
                    table += "</tr>";
                }
                table += "</table>";
                $("#table").html(table);
            },
            error: function (e) {
                alert("error in display all countries");
                alert(e.responseText);
            },
            async: false
        });
    }
    Display();

    //Add country
    $("#btnAdd").click(function () {
        var data = {
            name: $("#txtName").val(),
            continent: $("#txtContinent").val()
        }
        $.ajax({
            url: "https://localhost:44399/api/Countries",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            success: function () {
                Display();
                $("#btnCancel").trigger("click");
            },
            error: function (e) {
                alert("error in add country");
                alert(e.responseText);
            },
            async: false
        });
    });

    //Edit country
    $(document).on("click", ".fas.fa-edit", function () {
        $.ajax({
            url: "https://localhost:44399/api/Countries/" + $(this).attr("value"),
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "JSON",
            success: function (data) {
                $("#ID").val(data.id);
                $("#txtName").val(data.name);
                $("#txtContinent").val(data.continent);
                $("#btnAdd").css("display", "none");
                $("#btnSave, #btnCancel").css("display", "block");
            },
            error: function (e) {
                alert("error in edit country");
                alert(e.responseText);
            },
            async: false
        });
    });

    //Update country
    $("#btnSave").click(function () {
        var data = {
            id: parseInt($("#ID").val()),
            name: $("#txtName").val(),
            continent: $("#txtContinent").val()
        }
        $.ajax({
            url: "https://localhost:44399/api/Countries/" + $("#ID").val(),
            type: "PUT",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            success: function () {
                Display();
                $("#btnCancel").trigger("click");
            },
            error: function (e) {
                alert("error in update country");
                alert(e.responseText);
            },
            async: false
        });
    });

    //hide cancel and update buttons
    $("#btnCancel").click(function () {
        $("#btnSave, #btnCancel").css("display", "none");
        $("#btnAdd").css("display", "block");
        $("#txtName").val("");
        $("#txtContinent").val("");
    });

    //remove country
    $(document).on("click", ".fas.fa-trash-alt", function () {
        var conf = confirm("Are you sure you want to delete this country?");
        if (conf) {
            $.ajax({
                url: "https://localhost:44399/api/Countries/" + $(this).attr("value"),
                type: "DELETE",
                contentType: "application/json; charset=utf-8",
                success: function () {
                    Display();
                    $("#btnCancel").trigger("click");
                },
                error: function (e) {
                    alert("error in delete country");
                    alert(e.responseText);
                },
                async: false
            });
        }
    });

});