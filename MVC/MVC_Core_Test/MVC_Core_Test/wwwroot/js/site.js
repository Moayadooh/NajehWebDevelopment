
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

function Select(start, end, className, selectedDatePart) {
    var message = $(className)[0];
    createSelection(message, start, end);
    message.value.substring(message.selectionStart, message.selectionEnd);
    if (start == 0)
        $(selectedDatePart).val(1);
    else if (start == 3)
        $(selectedDatePart).val(2);
    else if (start == 6)
        $(selectedDatePart).val(3);
}

function SelectNextPartOfDate(e, className, selectedDatePart) {
    e.preventDefault();
    var date = $(className).val().split("/");
    if ($(selectedDatePart).val() == 0)
        Select(0, date[0].length, className, selectedDatePart);
    else if ($(selectedDatePart).val() == 1)
        Select(date[0].length + 1, date[0].length + date[1].length + 1, className, selectedDatePart);
    else if ($(selectedDatePart).val() == 2)
        Select($(className).val().length - 4, $(className).val().length, className, selectedDatePart);
    else if ($(selectedDatePart).val() == 3)
        Select(0, date[0].length, className, selectedDatePart);
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

function CheckDate(className, selectedDatePart) {
    var date = $(className).val().split("/");

    //Day
    var currentDay = "", newDay = "";
    if (typeof date[0] === 'undefined' || date[0] == '')
        currentDay = "dd";
    else
        currentDay = date[0];
    newDay = CheckPartOfDate(currentDay, "dd", 1, className, selectedDatePart);

    //Month
    var currentMonth = "", newMonth = "";
    if (typeof date[1] === 'undefined' || date[1] == '')
        currentMonth = "mm";
    else
        currentMonth = date[1];
    newMonth = CheckPartOfDate(currentMonth, "mm", 1, className, selectedDatePart);

    //Year
    var currentYear = "", newYear = "";
    if (typeof date[2] === 'undefined' || date[2] == '')
        currentYear = "yyyy";
    else
        currentYear = date[2];
    newYear = CheckPartOfDate(currentYear, "yyyy", 3, className, selectedDatePart);

    $(className).val(newDay + "/" + newMonth + "/" + newYear);
}

function CheckPartOfDate(currentDate, format, len, className, selectedDatePart) {
    var date = $(className).val().split("/");

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
    if ($(className).val().length == 10) {
        if (!isNaN(newDate) && newDate.length > 1 && isNaN(date[1]) && date[1].length > 1) {
            Select(3, 5, className, selectedDatePart);
        }
        else if (!isNaN(date[1]) && date[1].length > 1 && isNaN(date[2]) && date[2].length > 3) {
            Select(6, 10, className, selectedDatePart);
        }
        else if (isNaN(date[0]) && !isNaN(date[1]) && !isNaN(date[2])) {
            Select(0, 2, className, selectedDatePart);
        }
        else if (!isNaN(date[0]) && !isNaN(date[1]) && !isNaN(date[2])) {
            Select(0, 2, className, selectedDatePart);
        }
    }
    return newDate;
}

function SelectPartOfDate(className, selectedDatePart) {
    var date = $(className).val().split("/");
    if (isNaN(date[0])) {
        Select(0, date[0].length, className, selectedDatePart);
    }
    else if (isNaN(date[1])) {
        Select(date[0].length + 1, date[0].length + date[1].length + 1, className, selectedDatePart);
    }
    else if (isNaN(date[2])) {
        Select($(className).val().length - 4, $(className).val().length, className, selectedDatePart);
    }
    else {
        Select(0, date[0].length, className, selectedDatePart);
    }
}

function PartToSelect(className, selectedDatePart) {
    var date = $(className).val().split("/");
    var partToSelect = 0;
    if (date[0].length < 2)
        partToSelect = 1;
    else if (date[1].length < 2)
        partToSelect = 2;
    else if (date[2].length < 4)
        partToSelect = 3;

    SetMaxAndMinDayAndMonth(className);
    Add0BeforeDigits(className);

    date = $(className).val().split("/");
    if (partToSelect == 1)
        Select(0, date[0].length, className, selectedDatePart);
    else if (partToSelect == 2)
        Select(date[0].length + 1, date[0].length + date[1].length + 1, className, selectedDatePart);
    else if (partToSelect == 3)
        Select($(className).val().length - 4, $(className).val().length, className, selectedDatePart);
}

function SetMaxAndMinDayAndMonth(className) {
    var date = $(className).val().split("/");

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

    $(className).val(date[0] + "/" + date[1] + "/" + date[2]);
}

function Add0BeforeDigits(className) {
    var date = $(className).val().split("/");

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

    $(className).val(date[0] + "/" + date[1] + "/" + date[2]);
}

function PreventDeleteText(className, selectedDatePart) {
    window.onkeydown = function (event) {
        if (event.which == 8 || event.which == 46) {
            event.preventDefault();
            PartToSelect(className, selectedDatePart);
        }
    };
}

function InputNumbersOnly(className) {
    $(className).bind({
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

function MoveToLeftAndRight(e, className, calendarDisplayed, selectedDatePart) {
    //Move in date parts
    var date = $(className).val().split("/");
    if (e.keyCode == '37') {
        e.preventDefault();
        if ($(calendarDisplayed).val() == 0) {
            if ($(className).val().length < 10) {
                PartToSelect(className, selectedDatePart);
            }
            else if ($(selectedDatePart).val() == 2)
                Select(0, date[0].length, className, selectedDatePart);
            else if ($(selectedDatePart).val() == 3)
                Select(date[0].length + 1, date[0].length + date[1].length + 1, className, selectedDatePart);
        }
    }
    else if (e.keyCode == '39') {
        e.preventDefault();
        if ($(calendarDisplayed).val() == 0) {
            if ($(className).val().length < 10) {
                PartToSelect(className, selectedDatePart);
            }
            else if ($(selectedDatePart).val() == 1)
                Select(date[0].length + 1, date[0].length + date[1].length + 1, className, selectedDatePart);
            else if ($(selectedDatePart).val() == 2)
                Select($(className).val().length - 4, $(className).val().length, className, selectedDatePart);
        }
    }
}

function EnterKeyPress(e, className) {
    //Press Enter key
    if (e.which == 13) {
        $(className).blur();
        Add0BeforeDigits(className);
    }
}

function DeleteKeyPress(e, className, selectedDatePart) {
    DeletePartOfDate(e, className, selectedDatePart);
}

function DeletePartOfDate(e, className, selectedDatePart) {
    //Press Backspace or Delete key
    if (e.keyCode == 8 || e.keyCode == 46) {
        e.preventDefault();
        if ($(className).val().length == 10) {
            var date = $(className).val().split("/");
            if (date[0] == 'dd' || date[1] == 'mm' || date[2] == 'yyyy') {
                if (date[1] != 'mm') {
                    date[1] = 'mm';
                    $(className).val(date[0] + "/" + date[1] + "/" + date[2]);
                    Select(date[0].length + 1, date[0].length + date[1].length + 1, className, selectedDatePart);
                }
                else if (date[0] != 'dd') {
                    date[0] = 'dd';
                    $(className).val(date[0] + "/" + date[1] + "/" + date[2]);
                    Select(0, date[0].length, className, selectedDatePart);
                }
                else if (date[2] != 'yyyy') {
                    date[2] = 'yyyy';
                    $(className).val(date[0] + "/" + date[1] + "/" + date[2]);
                    Select($(className).val().length - 4, $(className).val().length, className, selectedDatePart);
                }
            }
            else {
                if ($(selectedDatePart).val() == 3) {
                    date[2] = 'yyyy';
                    $(className).val(date[0] + "/" + date[1] + "/" + date[2]);
                    Select($(className).val().length - 4, $(className).val().length, className, selectedDatePart);
                }
                else if ($(selectedDatePart).val() == 2) {
                    date[1] = 'mm';
                    $(className).val(date[0] + "/" + date[1] + "/" + date[2]);
                    Select(date[0].length + 1, date[0].length + date[1].length + 1, className, selectedDatePart);
                }
                else if ($(selectedDatePart).val() == 1) {
                    date[0] = 'dd';
                    $(className).val(date[0] + "/" + date[1] + "/" + date[2]);
                    Select(0, date[0].length, className, selectedDatePart);
                }
            }
        }
    }
}

function ClickEvent(className, calendarDisplayed, selectedDatePart) {
    if ($(className).val().length > 0 && $(calendarDisplayed).val() == 1) {
        $(className).val("");
        $(className).next("span").find("button").trigger("click");
    }
    if ($(className).val().length == 0 && $(calendarDisplayed).val() == 0) {
        CheckDate(className, selectedDatePart);
        SelectPartOfDate(className, selectedDatePart);
    }
}

function InputEvent(className, selectedDatePart) {
    if ($(className).val().length == 10)
        SetMaxAndMinDayAndMonth(className);
    CheckDate(className, selectedDatePart);
}

function SelectEvent(className, selectedDatePart) {
    PreventDeleteText(className, selectedDatePart);
}

//Disable Up and Down Arrows keys
var ar = new Array(38, 40);
var disableArrowKeys = function (e) {
    if ($.inArray(e.keyCode, ar) >= 0) {
        e.preventDefault();
    }
}

function MouseClickEvent(e, className, selectedDatePart) {
    if ($(className).val().length > 0)
        Add0BeforeDigits(className);
    SelectNextPartOfDate(e, className, selectedDatePart);
}

function BlurEvent(className, selectedDatePart) {
    //CheckDate(className, selectedDatePart);
    Add0BeforeDigits(className);
}

function DatePickerConfig(className, calendarDisplayed) {
    //Library Documentation
    //https://gijgo.com/datepicker/
    $(className).datepicker({
        uiLibrary: 'bootstrap4',
        iconsLibrary: 'fontawesome',
        format: 'dd/mm/yyyy',
        showOnFocus: false,
        keyboardNavigation: true,
        width: 234,
        size: 'small',
        open: function (e) {
            $(calendarDisplayed).val(1);
            $(className).val("");
        },
        close: function (e) {
            $(calendarDisplayed).val(0);
        }
    });
}

function DatePicker(className, calendarDisplayed, selectedDatePart) {
    InputNumbersOnly(className);

    $(className).mousedown(function (e) {
        MouseClickEvent(e, className, selectedDatePart);
    });

    $(className).keydown(function (e) {
        MoveToLeftAndRight(e, className, calendarDisplayed, selectedDatePart);
    });

    $(className).keydown(disableArrowKeys);

    $(className).on('keypress', function (e) {
        EnterKeyPress(e, className);
    });

    $(className).keyup(function (e) {
        DeleteKeyPress(e, className, selectedDatePart);
    });

    $(className).on("click", function () {
        ClickEvent(className, calendarDisplayed, selectedDatePart);
    });

    $(className).on("input", function () {
        InputEvent(className, selectedDatePart);
    });

    $(className).on('select', function () {
        SelectEvent(className, selectedDatePart);
    });

    $(className).on('blur', function () {
        BlurEvent(className, selectedDatePart);
    });

    //jQuery(className).on("invalid", function (event) {
    //    event.target.setCustomValidity('Please enter valid date.');
    //});
}

$(function () {
    DatePickerConfig(".datepicker1", "#datepicker1-calendar-displayed");
    DatePicker(".datepicker1", "#datepicker1-calendar-displayed", "#datepicker1-selected-date-part");

    DatePickerConfig(".datepicker2", "#datepicker2-calendar-displayed");
    DatePicker(".datepicker2", "#datepicker2-calendar-displayed", "#datepicker2-selected-date-part");

    DatePickerConfig(".datepicker3", "#datepicker3-calendar-displayed");
    DatePicker(".datepicker3", "#datepicker3-calendar-displayed", "#datepicker3-selected-date-part");

    DatePickerConfig(".datepicker4", "#datepicker4-calendar-displayed");
    DatePicker(".datepicker4", "#datepicker4-calendar-displayed", "#datepicker4-selected-date-part");
});