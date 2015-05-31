var model = "Model",
    brand = "Brand",
    socket = "Socket",
    format = "Format",
    gpuId = "#GpuId",
    gpuView = "#GpuView",
    gpuBrand = "#GpuBrand",
    gpuManufacturer = "#GpuManufacturer",
    cpuId = "#CpuId",
    cpuView = "#CpuView",
    cpuBrand = "#CpuBrand",
    cpuSocket = "#CpuSocket",
    storageId = "#StorageId",
    storageView = "#StorageView",
    storageBrand = "#StorageBrand",
    storageCapacity = "#StorageCapacity",
    memoryId = "#MemoryId",
    memoryView = "#MemoryView",
    memoryBrand = "#MemoryBrand",
    memoryCapacity = "#MemoryCapacity",
    motherboardId = "#MotherboardId",
    motherboardFormat = "#MotherboardFormat",
    motherboardBrand = "#MotherboardBrand",
    motherboardView = "#MotherboardView",
    psuBrand = "#PsuBrand",
    psuView = "#PsuView",
    psuId = "#PsuId",
    caseBrand = "#CaseBrand",
    caseId = "#CaseId",
    caseView = "#CaseView",
    formId = "#ConfigurationForm",
    motherboardFormatUrl = "/Motherboard/LoadMotherboardFormat",
    psuBrandUrl = "/Psu/LoadPsuBrand",
    caseBrandUrl = "/Case/LoadCaseBrand";

var gpuGroup = new DropdownListGroup(
    new DropdownList(gpuManufacturer, ""),
    new DropdownList(gpuBrand, brand),
    new DropdownList(gpuId, model),
    gpuView);

var memoryGroup = new DropdownListGroup(
    new DropdownList(memoryCapacity, ""),
    new DropdownList(memoryBrand, brand),
    new DropdownList(memoryId, model),
    memoryView);

var cpuGroup = new DropdownListGroup(
    new DropdownList(cpuBrand, ""),
    new DropdownList(cpuSocket, socket),
    new DropdownList(cpuId, model),
    cpuView);

var storageGroup = new DropdownListGroup(
    new DropdownList(storageCapacity, ""),
    new DropdownList(storageBrand, brand),
    new DropdownList(storageId, model),
    storageView);

var moboGroup = new DropdownListGroup(
    new DropdownList(motherboardFormat, format),
    new DropdownList(motherboardBrand, brand),
    new DropdownList(motherboardId, model),
    motherboardView);

var psuGroup = new DropdownListGroup(
    undefined,
    new DropdownList(psuBrand, brand),
    new DropdownList(psuId, model),
    psuView
    );

var caseGroup = new DropdownListGroup(
    undefined,
    new DropdownList(caseBrand, brand),
    new DropdownList(caseId, model),
    caseView
    );

function DropdownList(identifier, label) {
    this.identifier = identifier;
    this.label = label;
}

function DropdownListGroup(first, second, third, view) {
    this.first = first;
    this.second = second;
    this.third = third;
    this.view = view;
}

function setupDropdownListGroup(group) {
    if (group.first != undefined) {
        $(group.first.identifier).unbind("change").change(function() {
            selectChangeWithTwoTargets(this, group.second.identifier, group.second.label, group.third.identifier, group.third.label, group.view);
        });
    }
    $(group.second.identifier).unbind("change").change(function () {
        selectChangeWithOneTarget(this, group.third.identifier, group.third.label, group.view);
    });
    $(group.third.identifier).unbind("change").change(function () {
        selectChangeComponent(this, group.view);
    });
}

$(document).ready(function () {
    var navListItems = $("ul.setup-panel li a"),
        allWells = $(".setup-content");

    allWells.hide();

    navListItems.click(function (e) {
        e.preventDefault();
        var $target = $($(this).attr("href")),
            $item = $(this).closest("li");

        if (!$item.hasClass("disabled")) {
            navListItems.closest("li").removeClass("active");
            $item.addClass("active");
            allWells.hide();
            $target.show();
        }
    });

    $("ul.setup-panel li.active a").trigger("click");

    $("#activate-step-2").on("click", function (e) {
        $("ul.setup-panel li:eq(1)").removeClass("disabled");
        $("ul.setup-panel li a[href=\"#step-2\"]").trigger("click");
        $(this).remove();
    });

    $("#saveConfig").on("click", function () {
        $(this).addClass("disabled");
        $.ajax({
            type: "POST",
            url: $(this).attr("data-url"),
            data: $(formId).serialize(),
            cache: false,
            success: function (data) {
                $("form").before('<div class="alert alert-success alert-dismissible" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><strong>Success!</strong> Configuration saved.</div>');
            }
        });
    });

    setupDropdownListGroup(psuGroup);
    setupDropdownListGroup(caseGroup);
    setupDropdownListGroup(gpuGroup);
    setupDropdownListGroup(moboGroup);
    setupDropdownListGroup(memoryGroup);
    setupDropdownListGroup(cpuGroup);
    setupDropdownListGroup(storageGroup);
});

function selectChangeWithTwoTargets(source, target1Id, target1Name, target2Id, target2Name, viewId, myUrl, forced) {
    myAjax(source,
        function (data) {
            fillFormDropDownList(target1Id, target1Name, data);
            $(target1Id).show();
            emptyAndHide(target2Id, target2Name);
            emptyAndHide(viewId);
        },
        function (data) {

        },
        function () {
            emptyAndHide(target1Id);
            emptyAndHide(target2Id);
            emptyAndHide(viewId);
        }, undefined, myUrl, forced);
}

function selectChangeWithOneTarget(source, targetId, targetName, viewId, myUrl, forced) {
    myAjax(source,
        function (data) {
            $(targetId).show();
            fillFormDropDownList(targetId, targetName, data);
            emptyAndHide(viewId);
        },
        function (data) {

        },
        function () {
            emptyAndHide(targetId);
            emptyAndHide(viewId);
        }, undefined, myUrl, forced);
}

function selectChangeComponent(source, view) {
    myAjax(source, function (data) {
        $(view).show();
        $(view).html(data);
        longIf();
    },
        function (data) { },
        function () {
            emptyAndHide(view);
        },
        { id: source.value });
}

function fillFormDropDownList(identifier, defaultName, items) {
    if (items.length > 0) {
        $(identifier).show();
        var result = "<option value selected>" + defaultName + "</option>";
        $.each(items, function(index, value) {
            result += "<option value=\"" + value.value + "\">" + value.text + "</option>";
        });
        $(identifier).html(result);
    } else {
        $("form").before('<div class="alert alert-warning alert-dismissible" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><strong>Sorry!</strong> No more components found matching your choices. Try changing your configuration.</div>');
        emptyAndHide(identifier);
    }
}

function myAjax(source, mySuccess, myFail, myElse, myData, myUrl, forced) {
    myUrl = typeof myUrl !== "undefined" ? myUrl : $(source).attr("data-url");
    myData = typeof myData !== "undefined" ? myData : $(formId).serialize();
    forced = typeof forced !== "undefined" ? forced : false;

    if (source.value || forced) {
        $.ajax({
            type: "POST",
            url: myUrl,
            data: myData,
            cache: false,
            success: function (data) {
                mySuccess(data);
            },
            fail: function (data) {
                myFail(data);
            },
            complete: function () {
                disableIfNotComplete();
                reloadProgressBar();
            }
        });
    } else {
        myElse();
        disableIfNotComplete();
        reloadProgressBar();
    }
}

function emptyAndHide(identifier) {
    $(identifier).hide();
    $(identifier).html("");
}

function reloadProgressBar() {
    var selected = 0;
    var total = 0;
    $(formId + " select").each(function () {
        if (this.value) {
            selected++;
        }
        total++;
    });
    var percent = (selected / total) * 100;
    if (percent === 100) {
        $(".progress-bar").removeClass("progress-bar-warning");
        $(".progress-bar").addClass("progress-bar-success");
    } else {
        $(".progress-bar").addClass("progress-bar-warning");
        $(".progress-bar").removeClass("progress-bar-success");
    }
    $(".progress-bar").css({ width: percent + "%" });
}

function loadMotherboadFormat() {
    selectChangeWithOneTarget($(motherboardFormat).parent().html(), motherboardFormat, format, motherboardView, motherboardFormatUrl, true);
    $("ul.setup-panel li:eq(4)").removeClass("disabled");
}

function loadPsuBrands() {
    selectChangeWithOneTarget($(psuBrand).parent().html(), psuBrand, brand, psuView, psuBrandUrl, true);
    $("ul.setup-panel li:eq(5)").removeClass("disabled");
}

function loadCaseBrands() {
    selectChangeWithOneTarget($(caseBrand).parent().html(), caseBrand, brand, caseView, caseBrandUrl, true);
    $("ul.setup-panel li:eq(6)").removeClass("disabled");
}

function loadConfirmation() {
    $("ul.setup-panel li:eq(7)").removeClass("disabled");
    var html = "<div class='panel panel-success'><div class='panel-heading'>Configuration</div><table class='table table-hover'>" +
        viewToListItem(cpuView, "Cpu") +
        viewToListItem(motherboardView, "Motherboard") +
        viewToListItem(caseView, "Case") +
        viewToListItem(storageView, "Storage") +
        viewToListItem(memoryView, "Memory") +
        viewToListItem(gpuView, "Gpu") +
        viewToListItem(psuView, "Psu") + "</table></div>";
    $("#recap").html(html);
}

function viewToListItem(view, label) {
    var text = $(view + " .panel-heading").text();
    var html = "<tr><td>" + label + "</td><td>" + text + "</td></tr>";
    return html;
}

function longIf() {
    if ($(memoryId).val() && $(cpuId).val() && $(storageId).val() && $(gpuId).val()) {
        if (!$(motherboardId).val()) {
            loadMotherboadFormat();
        } else if (!$(psuId).val()) {
            loadPsuBrands();
        } else if (!$(caseId).val()) {
            loadCaseBrands();
        } else {
            loadConfirmation();
        }
    }
}

function disableMobo() {
    $("ul.setup-panel li:eq(4)").addClass("disabled");
    emptyAndHide(motherboardFormat);
    emptyAndHide(motherboardId);
    emptyAndHide(motherboardBrand);
    emptyAndHide(motherboardView);
}

function disablePsu() {
    $("ul.setup-panel li:eq(5)").addClass("disabled");
    emptyAndHide(psuBrand);
    emptyAndHide(psuId);
    emptyAndHide(psuView);
}

function disableCase() {
    $("ul.setup-panel li:eq(6)").addClass("disabled");
    emptyAndHide(caseBrand);
    emptyAndHide(caseId);
    emptyAndHide(caseView);
}

function disableConfirmation() {
    $("ul.setup-panel li:eq(7)").addClass("disabled");
}

function disableIfNotComplete() {
    if (!$(cpuId).val() || !$(gpuId).val() || !$(memoryId).val() || !$(storageId).val()) {
        if (!$("ul.setup-panel li:eq(4)").hasClass("disabled")) {
            disableMobo();
        }
        if (!$("ul.setup-panel li:eq(5)").hasClass("disabled")) {
            disablePsu();
        }
        if (!$("ul.setup-panel li:eq(6)").hasClass("disabled")) {
            disableCase();
        }
        if (!$("ul.setup-panel li:eq(7)").hasClass("disabled")) {
            disableConfirmation();
        }
    } else if (!$(motherboardId).val()) {
        if (!$("ul.setup-panel li:eq(5)").hasClass("disabled")) {
            disablePsu();
        }
        if (!$("ul.setup-panel li:eq(6)").hasClass("disabled")) {
            disableCase();
        }
        if (!$("ul.setup-panel li:eq(7)").hasClass("disabled")) {
            disableConfirmation();
        }
    } else if (!$(psuId).val()) {
        if (!$("ul.setup-panel li:eq(6)").hasClass("disabled")) {
            disableCase();
        }
        if (!$("ul.setup-panel li:eq(7)").hasClass("disabled")) {
            disableConfirmation();
        }
    }
}