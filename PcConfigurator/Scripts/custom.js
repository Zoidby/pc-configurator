$(document).ready(function () {
    $('#tabsleft').bootstrapWizard({
        'tabClass': 'nav nav-pills', 'debug': false,
        onShow: function (tab, navigation, index) {
        }, onNext: function (tab, navigation, index) {
        }, onPrevious: function (tab, navigation, index) {
        }, onTabClick: function (tab, navigation, index) {
        }, onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index + 1;
            var $percent = ($current / $total) * 100;
            $('#tabsleft .progress-bar').css({ width: $percent + '%' });
            // If it's the last tab then hide the last button and show the finish instead
            if ($current >= $total) {
                $('#tabsleft').find('.pager .next').hide();
                $('#tabsleft').find('.pager .finish').show();
                $('#tabsleft').find('.pager .finish').removeClass('disabled');
            } else {
                $('#tabsleft').find('.pager .next').show();
                $('#tabsleft').find('.pager .finish').hide();
            }
        }
    });

    $('#tabsleft .finish').unbind('click').click(function () {
        myAjax($("#configurationForm").attr('action'), $("#configurationForm").serialize(), function(data) { console.log(data); }, function(data) {});
        return false;
    });
});


$("#CpuBrand").unbind('change').change(function () {
    var target1Id = "#CpuSocket";
    var target1Name = "Socket";
    var target2Id = "#CpuId";
    var target2Name = "Cpu";

    if ($(this).val()) {
        myAjax($(this).attr("data-url"), $("#configurationForm").serialize(),
            function(data) {
                fillFormDropDownList(target1Id, target1Name, data);
                $(target1Id).show();
                emptyAndHide(target2Id, target2Name);
            },
            function(data) {
                
            });
    } else {
        emptyAndHide(target1Id, target1Name);
        emptyAndHide(target2Id, target2Name);
    }
});

$("#CpuSocket").unbind('change').change(function () {
    var targetId = "#CpuId";
    if (this.value) {
        myAjax($(this).attr("data-url"), $("#configurationForm").serialize(),
            function(data) {
                fillFormDropDownList(targetId, "Cpu", data);
                $(targetId).show();
            },
            function(data) {

            });
    } else {
        emptyAndHide(targetId);
    }
});

function fillFormDropDownList(identifier, defaultName, items) {
    var result = "<option value selected>"+defaultName+"</option>";
    $.each(items, function (index, value) {
        result += '<option value="' + value.value + '">' + value.text + '</option>';
    });
    $(identifier).html(result);
}
function myAjax(myUrl, myData, mySuccess, myFail) {
    $.ajax({
        type: "POST",
        url: myUrl,
        data: myData,
        cache: false,
        success: function (data) {
            mySuccess(data);
        },
        fail: function(data) {
            myFail(data);
        }
    });
}

function emptyAndHide(identifier, name) {
    $(identifier).hide();
    fillFormDropDownList(identifier, name, []);
}