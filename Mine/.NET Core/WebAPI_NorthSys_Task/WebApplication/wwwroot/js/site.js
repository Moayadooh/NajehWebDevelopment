$(function () {

    //Display all records
    function Display() {
        $.ajax({
            url: "https://localhost:44366/api/Courses",
            type: "GET",
            contentType: "application/json ; charset=utf-8",
            dataType: "JSON",
            success: function (data) {
                var table = "<table class='table table-hover' style='background:white;'>";
                table += "<tr><th>Course Code</th>";
                table += "<th>Course Name</th>";
                table += "<th>Date & Time</th>";
                table += "<th>Edit</th>";
                table += "<th>Delete</th></tr>";
                for (var i = 0; i < data.length; i++) {
                    table += "<tr>";
                    table += "<td>" + data[i].courseCode + "</td>";
                    table += "<td>" + data[i].courseName + "</td>";
                    table += "<td>" + data[i].date + "</td>";
                    table += "<td><i class='fas fa-edit' value=" + data[i].id + "></i></td>";
                    table += "<td><i class='fas fa-trash-alt' value=" + data[i].id + "></i></td>";
                    table += "</tr>";
                }
                table += "</table>";
                $("#table").html(table);
            },
            error: function (e) {
                alert("error in display all records");
                alert(e.responseText);
            },
            async: false
        });
    }
    Display();

    //Add record
    $("#btnAdd").click(function () {
        //var data = {
        //    courseCode: $("#txtCourseCode").val(),
        //    courseName: $("#txtCourseName").val(),
        //    date: $("#txtDate").val()
        //}
        $.ajax({
            url: "https://localhost:44366/api/Courses/" + $("#txtCourseCode").val() + "/" + $("#txtCourseName").val() + "/" + $("#txtDate").val(),
            type: "POST",
            contentType: "application/json; charset=utf-8",
            //data: JSON.stringify(data),
            success: function () {
                Display();
                $("#btnCancel").trigger("click");
            },
            error: function (e) {
                alert("error in add record");
                alert(e.responseText);
            },
            async: false
        });
    });

    //Edit record
    $(document).on("click", ".fas.fa-edit", function () {
        $.ajax({
            url: "https://localhost:44366/api/Courses/" + $(this).attr("value"),
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "JSON",
            success: function (data) {
                $("#ID").val(data.id);
                $("#txtCourseCode").val(data.courseCode);
                $("#txtCourseName").val(data.courseName);
                $("#txtDate").val(data.date);
                $("#btnAdd").css("display", "none");
                $("#btnSave, #btnCancel").css("display", "block");
            },
            error: function (e) {
                alert("error in edit record");
                alert(e.responseText);
            },
            async: false
        });
    });

    //Update record
    $("#btnSave").click(function () {
        //var data = {
        //    id: $("#ID").val(),
        //    courseCode: $("#txtCourseCode").val(),
        //    courseName: $("#txtCourseName").val(),
        //    date: $("#txtDate").val()
        //}
        $.ajax({
            url: "https://localhost:44366/api/Courses/" + $("#ID").val() + "/" + $("#txtCourseCode").val() + "/" + $("#txtCourseName").val() + "/" + $("#txtDate").val(),
            type: "PUT",
            contentType: "application/json; charset=utf-8",
            //data: JSON.stringify(data),
            success: function () {
                Display();
                $("#btnCancel").trigger("click");
            },
            error: function (e) {
                alert("error in update record");
                alert(e.responseText);
            },
            async: false
        });
    });

    //hide cancel and update buttons
    $("#btnCancel").click(function () {
        $("#btnSave, #btnCancel").css("display", "none");
        $("#btnAdd").css("display", "block");
        $("#txtCourseCode").val("");
        $("#txtCourseName").val("");
        $("#txtDate").val("");
    });

    //remove record
    $(document).on("click", ".fas.fa-trash-alt", function () {
        var conf = confirm("Are you sure you want to delete this record?");
        if (conf) {
            $.ajax({
                url: "https://localhost:44366/api/Courses/" + $(this).attr("value"),
                type: "DELETE",
                contentType: "application/json; charset=utf-8",
                success: function () {
                    Display();
                    $("#btnCancel").trigger("click");
                },
                error: function (e) {
                    alert("error in remove record");
                    alert(e.responseText);
                },
                async: false
            });
        }
    });

});