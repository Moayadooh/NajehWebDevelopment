// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
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
    var message = $('.datepickerFrom')[0];
    createSelection(message, start, end);
    message.value.substring(message.selectionStart, message.selectionEnd);
}

function SelectPartOfDate() {
    var date = $('.datepickerFrom').val().split("/");
    if (isNaN(date[0])) {
        //Select(0, 2);
        Select(0, date[0].length);
    }
    else if (isNaN(date[1])) {
        //Select(3, 5);
        Select(date[0].length + 1, date[0].length + date[1].length + 1);
    }
    else if (isNaN(date[2])) {
        //Select(6, 10);
        Select($('.datepickerFrom').val().length - 4, $('.datepickerFrom').val().length);
    }
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

$('.datepickerFrom').datepicker({
    uiLibrary: 'bootstrap4',
    iconsLibrary: 'fontawesome',
    format: 'dd/mm/yyyy',
    showOnFocus: false,
    //value: 'dd/mm/yyyy',
    //width: 234
    //keyboardNavigation: true
    //size: 'small'
});

$(function () {
    $('.datepickerFrom').click(function () {
        SelectPartOfDate();
    });

    function CheckDate() {
        var date = $('.datepickerFrom').val().split("/");
        function CheckPartOfDate(currentDate, format, len) {
            var newDate = "";
            for (var i = 0; i < currentDate.length; i++) {
                if (!isNaN(currentDate[i]))
                    newDate += currentDate[i];
                if (isNaN(currentDate))
                    newDate = format;
                if (i == len)
                    break;
            }
            if ($('.datepickerFrom').val().length != 9) {
                if (!isNaN(newDate) && newDate.length > 1 && isNaN(date[1]) && date[1].length > 1) {
                    Select(3, 5);
                }
                else if (!isNaN(date[1]) && date[1].length > 1 && isNaN(date[2]) && date[2].length > 3) {
                    Select(6, 10);
                }
            }
            return newDate;
        }

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

        $('.datepickerFrom').val(newDay + "/" + newMonth + "/" + newYear);
    }

    $('.datepickerFrom').on("input", function () {
        CheckDate();
    });

    //Press Backspace key
    $(document).keyup(function (e) {
        if (e.keyCode == 8) {
            if ($('.datepickerFrom').val().length != 9) {
                var date = $('.datepickerFrom').val().split("/");
                if (date[0] == 'dd' || date[1] == 'mm' || date[2] == 'yyyy') {
                    if (date[2] != 'yyyy')
                        date[2] = 'yyyy';
                    else if (date[1] != 'mm')
                        date[1] = 'mm';
                    else if (date[0] != 'dd')
                        date[0] = 'dd';
                    console.log(1);
                }
                else {
                    if (date[2] == getSelectionText())
                        date[2] = 'yyyy';
                    else if (date[1] == getSelectionText())
                        date[1] = 'mm';
                    else if (date[0] == getSelectionText())
                        date[0] = 'dd';
                    console.log(2);
                }

                //if (date[2] == 'yyyy') {
                //    if (date[1] == 'mm')
                //        date[0] = 'dd';
                //    else
                //        date[1] = 'mm';
                //}

                //if (typeof date[2].length == 0)
                //    date[2] = 'yyyy';
                //else if (typeof date[1].length == 0)
                //    date[1] = 'mm';
                //else if (typeof date[0].length == 0)
                //    date[0] = 'dd';

                $('.datepickerFrom').val(date[0] + "/" + date[1] + "/" + date[2]);
                SelectPartOfDate();
            }
        }
    });

    //Input number only
    $(".datepickerFrom").bind({
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

    $('.datepickerFrom').on("focus", function () {
        CheckDate();
        SelectPartOfDate();

        //Disable Arrows keys
        var ar = new Array(38, 40);
        var disableArrowKeys = function (e) {
            if ($.inArray(e.keyCode, ar) >= 0) {
                e.preventDefault();
            }
        }
        $(document).keydown(disableArrowKeys);

        //Press Enter key
        $(document).on('keypress', function (e) {
            if (e.which == 13) {
                $('.datepickerFrom').blur();
                SetMaxAndMinDayAndMonth();
            }
        });

        $('.datepickerFrom').blur(function () {
            SetMaxAndMinDayAndMonth();
        });

        //Prevent delete '/' character
        $('.datepickerFrom')[0].addEventListener("keydown", function (e) {
            var start = this.selectionStart,
                end = this.selectionEnd,
                value = this.value,
                key = e.keyCode;

            if (key == 8 && value[start - 1] == '/') e.preventDefault();
            if (key == 46 && value[start] == '/') e.preventDefault();
            if ((key == 8 || key == 46) && value.substring(start, end).indexOf('/') != -1) e.preventDefault();

        }, false);

        function SetMaxAndMinDayAndMonth() {
            var date = $('.datepickerFrom').val().split("/");

            //Set max month to 12 & min month to 1
            if (!isNaN(date[1]) && date[1] > 12)
                date[1] = 12;
            else if (!isNaN(date[1]) && date[1] < 1)
                date[1] = 1;

            //Set max day to 31 & min day to 1
            if (!isNaN(date[0]) && !isNaN(date[1]) && (date[1] == 1 || date[1] == 3 || date[1] == 5 || date[1] == 7 || date[1] == 8 || date[1] == 10 || date[1] == 12)) {
                if (!isNaN(date[0]) && date[0] > 31)
                    date[0] = 31;
                else if (!isNaN(date[0]) && date[0] < 1)
                    date[0] = 1;
            }

            if (!isNaN(date[0]) && date[0].length == 1)
                date[0] = '0' + date[0];

            if (!isNaN(date[1]) && date[1].length == 1)
                date[1] = '0' + date[1];

            $('.datepickerFrom').val(date[0] + "/" + date[1] + "/" + date[2]);
        }

    });

    jQuery(".datepickerFrom").on("valid", function (event) {
        event.target.setCustomValidity('Please enter valid date.');
    });
});