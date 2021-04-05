$(function () {

    //Display all majors
    function Display() {
        $.ajax({
            url: "https://localhost:44365/api/Majors",
            type: "GET",
            contentType: "application/json ; charset=utf-8",
            dataType: "JSON",
            success: function (data) {
                var table = "<table class='table table-hover' style='background:white;'>";
                table += "<tr><th>Title</th>";
                table += "<th>Total Hours</th>";
                table += "<th>Price</th>";
                table += "<th>Start Date</th>";
                table += "<th>End Date</th>";
                table += "<th>Edit</th>";
                table += "<th>Delete</th></tr>";
                for (var i = 0; i < data.length; i++) {
                    table += "<tr>";
                    table += "<td>" + data[i].Title + "</td>";
                    table += "<td>" + data[i].TotalHours + "</td>";
                    table += "<td>" + data[i].Price + "</td>";
                    table += "<td>" + data[i].StartDate + "</td>";
                    table += "<td>" + data[i].EndDate + "</td>";
                    table += "<td><i class='fas fa-edit' value=" + data[i].ID + "></i></td>";
                    table += "<td><i class='fas fa-trash-alt' value=" + data[i].ID + "></i></td>";
                    table += "</tr>";
                }
                table += "</table>";
                $("#table").html(table);
            },
            error: function (e) {
                alert("error display all majors");
                alert(e.responseText);
            },
            async: false
        });
    }
    Display();

    //Add major
    $("#btnAdd").click(function () {
        var data = {
            Title: $("#txtTitle").val(),
            TotalHours: $("#txtTotalHours").val(),
            Price: $("#txtPrice").val(),
            StartDate: $("#txtStartDate").val(),
            EndDate: $("#txtEndDate").val()
        }
        $.ajax({
            url: "https://localhost:44365/api/Majors",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "JSON",
            data: JSON.stringify(data),
            success: function () {
                Display();
                $("#btnCancel").trigger("click");
            },
            error: function (e) {
                alert("error in add major");
                alert(e.responseText);
            },
            async: false
        });
    });

    //Edit major
    $(document).on("click", ".fas.fa-edit", function () {
        $.ajax({
            url: "https://localhost:44365/api/Majors/" + $(this).attr("value"),
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "JSON",
            success: function (data) {
                $("#ID").val(data.ID);
                $("#txtTitle").val(data.Title);
                $("#txtTotalHours").val(data.TotalHours);
                $("#txtPrice").val(data.Price);
                $("#txtStartDate").val(data.StartDate);
                $("#txtEndDate").val(data.EndDate);
                $("#btnAdd").css("display", "none");
                $("#btnSave, #btnCancel").css("display", "block");
            },
            error: function (e) {
                alert("error in edit major");
                alert(e.responseText);
            },
            async: false
        });
    });

    //Update major
    $("#btnSave").click(function () {
        var data = {
            ID: $("#ID").val(),
            Title: $("#txtTitle").val(),
            TotalHours: $("#txtTotalHours").val(),
            Price: $("#txtPrice").val(),
            StartDate: $("#txtStartDate").val(),
            EndDate: $("#txtEndDate").val()
        }
        $.ajax({
            url: "https://localhost:44365/api/Majors/" + $("#ID").val(),
            type: "PUT",
            contentType: "application/json; charset=utf-8",
            dataType: "JSON",
            data: JSON.stringify(data),
            success: function () {
                Display();
                $("#btnCancel").trigger("click");
            },
            error: function (e) {
                alert("error in update major");
                alert(e.responseText);
            },
            async: false
        });
    });

    //Hide cancel and update buttons
    $("#btnCancel").click(function () {
        $("#btnSave, #btnCancel").css("display", "none");
        $("#btnAdd").css("display", "block");
        $("#txtTitle").val("");
        $("#txtTotalHours").val("");
        $("#txtPrice").val("");
        $("#txtStartDate").val("");
        $("#txtEndDate").val("");
    });

    //Remove major
    $(document).on("click", ".fas.fa-trash-alt", function () {
        var conf = confirm("Are you sure you want to delete this major?");
        if (conf) {
            $.ajax({
                url: "https://localhost:44365/api/Majors/" + $(this).attr("value"),
                type: "DELETE",
                contentType: "application/json; charset=utf-8",
                success: function () {
                    Display();
                    $("#btnCancel").trigger("click");
                },
                error: function (e) {
                    alert("error in remove major");
                    alert(e.responseText);
                },
                async: false
            });
        }
    });

});