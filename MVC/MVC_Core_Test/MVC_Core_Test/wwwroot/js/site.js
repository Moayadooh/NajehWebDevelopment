
function createSelection(field, start, end) {
    if (field.createTextRange) {
        var selRange = field.createTextRange();
        selRange.collapse(true);
        selRange.moveStart('character', start);
        selRange.moveEnd('character', end);
        selRange.select();
        field.focus();
    } else if (field.setSelectionRange) {
        field.focus();
        field.setSelectionRange(start, end);
    } else if (typeof field.selectionStart != 'undefined') {
        field.selectionStart = start;
        field.selectionEnd = end;
        field.focus();
    }
}

function Select(start, end) {
    var message = $('.datepicker')[0];
    createSelection(message, start, end);
    message.value.substring(message.selectionStart, message.selectionEnd);
    if (start == 0)
        $("#datepicker-selected-date-part").val(1);
    else if (start == 3)
        $("#datepicker-selected-date-part").val(2);
    else if (start == 6)
        $("#datepicker-selected-date-part").val(3);
}

function SelectNextPartOfDate(e) {
    e.preventDefault();
    var date = $('.datepicker').val().split("/");
    if ($("#datepicker-selected-date-part").val() == 0)
        Select(0, date[0].length);
    else if ($("#datepicker-selected-date-part").val() == 1)
        Select(date[0].length + 1, date[0].length + date[1].length + 1);
    else if ($("#datepicker-selected-date-part").val() == 2)
        Select($('.datepicker').val().length - 4, $('.datepicker').val().length);
    else if ($("#datepicker-selected-date-part").val() == 3)
        Select(0, date[0].length);
}

function getSelectionText() {
    var text = "";
    if (window.getSelection) {
        text = window.getSelection().toString();
    } else if (document.selection && document.selection.type != "Control") {
        text = document.selection.createRange().text;
    }
    return text;
}

function CheckDate() {
    var date = $('.datepicker').val().split("/");

    //Day
    var currentDay = "", newDay = "";
    if (typeof date[0] === 'undefined' || date[0] == '')
        currentDay = "dd";
    else
        currentDay = date[0];
    newDay = CheckPartOfDate(currentDay, "dd", 1);

    //Month
    var currentMonth = "", newMonth = "";
    if (typeof date[1] === 'undefined' || date[1] == '')
        currentMonth = "mm";
    else
        currentMonth = date[1];
    newMonth = CheckPartOfDate(currentMonth, "mm", 1);

    //Year
    var currentYear = "", newYear = "";
    if (typeof date[2] === 'undefined' || date[2] == '')
        currentYear = "yyyy";
    else
        currentYear = date[2];
    newYear = CheckPartOfDate(currentYear, "yyyy", 3);

    $('.datepicker').val(newDay + "/" + newMonth + "/" + newYear);
}

function CheckPartOfDate(currentDate, format, len) {
    var date = $('.datepicker').val().split("/");

    var newDate = "";
    for (var i = 0; i < currentDate.length; i++) {
        if (!isNaN(currentDate[i]))
            newDate += currentDate[i];
        if (isNaN(currentDate)) {
            newDate = format;
        }
        if (i == len)
            break;
    }
    if ($('.datepicker').val().length == 10) {
        if (!isNaN(newDate) && newDate.length > 1 && isNaN(date[1]) && date[1].length > 1) {
            Select(3, 5);
        }
        else if (!isNaN(date[1]) && date[1].length > 1 && isNaN(date[2]) && date[2].length > 3) {
            Select(6, 10);
        }
        else if (isNaN(date[0]) && !isNaN(date[1]) && !isNaN(date[2])) {
            Select(0, 2);
        }
        else if (!isNaN(date[0]) && !isNaN(date[1]) && !isNaN(date[2])) {
            Select(0, 2);
        }
    }
    return newDate;
}

function SelectPartOfDate() {
    var date = $('.datepicker').val().split("/");
    if (isNaN(date[0])) {
        Select(0, date[0].length);
    }
    else if (isNaN(date[1])) {
        Select(date[0].length + 1, date[0].length + date[1].length + 1);
    }
    else if (isNaN(date[2])) {
        Select($('.datepicker').val().length - 4, $('.datepicker').val().length);
    }
    else {
        Select(0, date[0].length);
    }
}

function PartToSelect() {
    var date = $('.datepicker').val().split("/");
    var partToSelect = 0;
    if (date[0].length < 2)
        partToSelect = 1;
    else if (date[1].length < 2)
        partToSelect = 2;
    else if (date[2].length < 4)
        partToSelect = 3;

    SetMaxAndMinDayAndMonth();
    Add0BeforeDigits();

    date = $('.datepicker').val().split("/");
    if (partToSelect == 1)
        Select(0, date[0].length);
    else if (partToSelect == 2)
        Select(date[0].length + 1, date[0].length + date[1].length + 1);
    else if (partToSelect == 3)
        Select($('.datepicker').val().length - 4, $('.datepicker').val().length);
}

function SetMaxAndMinDayAndMonth() {
    var date = $('.datepicker').val().split("/");

    //Set max month to 12 & min month to 1
    if (!isNaN(date[1]) && date[1] > 12)
        date[1] = 12;
    else if (!isNaN(date[1]) && date[1] < 1)
        date[1] = 1;

    //Set max day to 31, 30 or 29 & min day to 1
    if (!isNaN(date[0]) && !isNaN(date[1]) && (date[1] == 1 || date[1] == 3 || date[1] == 5 || date[1] == 7 || date[1] == 8 || date[1] == 10 || date[1] == 12)) {
        if (date[0] > 31)
            date[0] = 31;
        else if (date[0] < 1)
            date[0] = 1;
    }
    else if (!isNaN(date[0]) && !isNaN(date[1]) && (date[1] == 4 || date[1] == 6 || date[1] == 9 || date[1] == 11)) {
        if (date[0] > 30)
            date[0] = 30;
        else if (date[0] < 1)
            date[0] = 1;
    }
    else if (!isNaN(date[0]) && !isNaN(date[1]) && (date[1] == 2)) {
        if (date[0] > 29)
            date[0] = 29;
        else if (date[0] < 1)
            date[0] = 1;
    }

    $('.datepicker').val(date[0] + "/" + date[1] + "/" + date[2]);
}

function Add0BeforeDigits() {
    var date = $('.datepicker').val().split("/");

    if (!isNaN(date[0]) && date[0].length == 1)
        date[0] = '0' + date[0];

    if (!isNaN(date[1]) && date[1].length == 1)
        date[1] = '0' + date[1];

    if (!isNaN(date[2]) && date[2].length == 1)
        date[2] = '000' + date[2];
    else if (!isNaN(date[2]) && date[2].length == 2)
        date[2] = '00' + date[2];
    else if (!isNaN(date[2]) && date[2].length == 3)
        date[2] = '0' + date[2];

    $('.datepicker').val(date[0] + "/" + date[1] + "/" + date[2]);
}

function PreventDeleteText() {
    window.onkeydown = function (event) {
        if (event.which == 8 || event.which == 46) {
            event.preventDefault();
            PartToSelect();
        }
    };
}

function InputNumbersOnly() {
    $(".datepicker").bind({
        keydown: function (e) {
            if (e.shiftKey === true) {
                if (e.which == 9) {
                    return true;
                }
                return false;
            }
            if (e.which == 13) {
                return true;
            }
            if (e.which >= 96 && e.which <= 105) {
                return true;
            }
            if (e.which > 57) {
                return false;
            }
            return true;
        }
    });
}

function MoveToLeftAndRight(e) {
    //Move in date parts
    var date = $('.datepicker').val().split("/");
    if (e.keyCode == '37') {
        e.preventDefault();
        if ($("#datepicker-calendar-displayed").val() == 0) {
            if ($('.datepicker').val().length < 10) {
                PartToSelect();
            }
            else if ($("#datepicker-selected-date-part").val() == 2)
                Select(0, date[0].length);
            else if ($("#datepicker-selected-date-part").val() == 3)
                Select(date[0].length + 1, date[0].length + date[1].length + 1);
        }
    }
    else if (e.keyCode == '39') {
        e.preventDefault();
        if ($("#datepicker-calendar-displayed").val() == 0) {
            if ($('.datepicker').val().length < 10) {
                PartToSelect();
            }
            else if ($("#datepicker-selected-date-part").val() == 1)
                Select(date[0].length + 1, date[0].length + date[1].length + 1);
            else if ($("#datepicker-selected-date-part").val() == 2)
                Select($('.datepicker').val().length - 4, $('.datepicker').val().length);
        }
    }
}

function BlurAndAdd0BeforeDigits(e) {
    //Press Enter key
    if (e.which == 13) {
        $('.datepicker').blur();
        Add0BeforeDigits();
    }
}

function DeletePartOfDate(e) {
    //Press Backspace or Delete key
    if (e.keyCode == 8 || e.keyCode == 46) {
        if ($('.datepicker').val().length == 10) {
            var date = $('.datepicker').val().split("/");
            if (date[0] == 'dd' || date[1] == 'mm' || date[2] == 'yyyy') {
                if (date[1] != 'mm') {
                    date[1] = 'mm';
                    $('.datepicker').val(date[0] + "/" + date[1] + "/" + date[2]);
                    Select(date[0].length + 1, date[0].length + date[1].length + 1);
                }
                else if (date[0] != 'dd') {
                    date[0] = 'dd';
                    $('.datepicker').val(date[0] + "/" + date[1] + "/" + date[2]);
                    Select(0, date[0].length);
                }
                else if (date[2] != 'yyyy') {
                    date[2] = 'yyyy';
                    $('.datepicker').val(date[0] + "/" + date[1] + "/" + date[2]);
                    Select($('.datepicker').val().length - 4, $('.datepicker').val().length);
                }
            }
            else {
                if ($("#datepicker-selected-date-part").val() == 3) {
                    date[2] = 'yyyy';
                    $('.datepicker').val(date[0] + "/" + date[1] + "/" + date[2]);
                    Select($('.datepicker').val().length - 4, $('.datepicker').val().length);
                }
                else if ($("#datepicker-selected-date-part").val() == 2) {
                    date[1] = 'mm';
                    $('.datepicker').val(date[0] + "/" + date[1] + "/" + date[2]);
                    Select(date[0].length + 1, date[0].length + date[1].length + 1);
                }
                else if ($("#datepicker-selected-date-part").val() == 1) {
                    date[0] = 'dd';
                    $('.datepicker').val(date[0] + "/" + date[1] + "/" + date[2]);
                    Select(0, date[0].length);
                }
            }
        }
    }
}

function ClickEvent(className, calendarDisplayedId) {
    if ($(calendarDisplayedId).val() == 1) {
        $(className).next("span").find("button").trigger("click");
    }
    if ($(className).val().length == 0) {
        CheckDate();
        SelectPartOfDate();
    }
}

function InputEvent(className) {
    if ($(className).val().length == 10)
        SetMaxAndMinDayAndMonth();
    CheckDate();
}

//Disable Up and Down Arrows keys
var ar = new Array(38, 40);
var disableArrowKeys = function (e) {
    if ($.inArray(e.keyCode, ar) >= 0) {
        e.preventDefault();
    }
}

$(function () {
    $('.datepicker').datepicker({
        uiLibrary: 'bootstrap4',
        iconsLibrary: 'fontawesome',
        format: 'dd/mm/yyyy',
        showOnFocus: false,
        keyboardNavigation: true,
        width: 234,
        size: 'small',
        open: function (e) {
            $("#datepicker-calendar-displayed").val(1);

        },
        close: function (e) {
            $("#datepicker-calendar-displayed").val(0);
        }
    });

    InputNumbersOnly();

    $(".datepicker").mousedown(function (e) {
        SelectNextPartOfDate(e);
    });

    $(".datepicker").keydown(function (e) {
        MoveToLeftAndRight(e);
    });

    $(".datepicker").keydown(disableArrowKeys);

    $(".datepicker").on('keypress', function (e) {
        BlurAndAdd0BeforeDigits(e);
    });

    $(".datepicker").keyup(function (e) {
        DeletePartOfDate(e);
    });

    $('.datepicker').on("click", function () {
        ClickEvent(".datepicker", "#datepicker-calendar-displayed");
    });

    $('.datepicker').on("input", function () {
        InputEvent(".datepicker");
    });

    $(".datepicker").on('select', function () {
        PreventDeleteText();
    });

    $('.datepicker').on('blur', function () {
        CheckDate();
        Add0BeforeDigits();
    });

    jQuery(".datepicker").on("invalid", function (event) {
        event.target.setCustomValidity('Please enter valid date.');
    });
});