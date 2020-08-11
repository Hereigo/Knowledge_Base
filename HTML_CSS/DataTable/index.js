var _pleaseWaitSettings = {
    message: '<i class="icon-spinner3 spinner"></i>',
    overlayCSS: {
        backgroundColor: '#fff',
        opacity: 0.8,
        cursor: 'wait'
    },
    css: {
        border: 0,
        padding: 0,
        backgroundColor: 'none'
    }
};

window._pleaseWaitSettings = _pleaseWaitSettings;

function FailedRequest(xhr) {
    alert(xhr.responseText);
}

function CampaignSaved() {
    window.location.href = "/Campaigns";
}

$(document).ready(function () {

    $('#campaigns-table').DataTable({
        dom: 'l<"toolbar">frtip',
        initComplete: function () {
            $("div.toolbar")
                .html(
                    '<button type="button" class="btn btn-primary change-status-js" data-status="Start">Start</button>' +
                    '<button type="button" class="btn btn-primary change-status-js" data-status="Stop">Stop</button>' +
                    '<button type="button" class="btn btn-primary change-status-js" data-status="Draft">Draft</button>' +
                    '<button type="button" class="btn btn-primary change-status-js" data-status="Archive">Archive</button>');
        },
        "processing": true,
        oLanguage: {
            sProcessing: "<div class='icon-spinner2 spinner'></div>"
        },
        "serverSide": true,
        "searching": false,
        "ajax": {
            "url": "/Campaigns/Search",
            "type": "Post"
        },
        "columns": [{
            "data": "number"
        }, {
            "data": "select"
        }, {
            "data": "name"
        }, {
            "data": "status"
        }, {
            "data": "last_sent"
        }, {
            "data": "open_rate"
        }, {
            "data": "push_sent_last_time"
        }],
        "fnServerData": function (sSource, aoData, fnCallback, oSettings) {
            var status = $('#status').val();
            if (status !== '') {
                aoData.push({
                    "name": "status",
                    "value": status
                });
            }
            $.ajax({
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "type": "POST",
                "url": "/Campaigns/Search",
                "data": JSON.stringify(aoData),
                "success": fnCallback
            });
        },
        columnDefs: [{
                "targets": 'no-sort',
                "orderable": false,
            },
            {
                targets: [0],
                render: function (data, type, row, meta) {
                    return meta.row + 1;
                }
            },
            {
                targets: [1],
                render: function (data, type, row, meta) {
                    return "<input type='checkbox' class='row-js' data-id='" + row.id + "'/>";
                }
            },
            {
                targets: [-1],
                render: function (data, type, row, meta) {
                    return "<a href='/Campaigns/" + row.id + "'><i class= 'icon-pencil text-orange'></i></a>";
                }
            }
        ]
    });

    $('#triger-all-rows-js').on('click', function () {
        var val = this.checked;
        $.each($('.row-js'), function (index, value) {
            value.checked = val;
        });

    });

    $(document).on('click', '.change-status-js', function () {
        var status = $(this).data('status');
        if (confirm("Do you really want to change staus of all selected campaigns to " + status + "?")) {

            ids = [];

            $.each($('.row-js:checked'), function (index, value) {
                ids.push($(value).data('id'));
            });

            var obj = {
                status: status,
                ids: ids
            };
            $.post('/Campaigns/ChangeStatus', obj, function (data, status) {
                if (status === 'success') {
                    var table = $('#campaigns-table').DataTable();
                    table.ajax.reload();
                    $('#triger-all-rows-js')[0].checked = false;
                } else {
                    alert(data);
                }
            });
        }
    });

    //==================================CAMPAIGN============================
    $('#DateStart').daterangepicker({
        singleDatePicker: true,
        timePicker: true,
        timePicker24Hour: true,
        timePickerIncrement: 1,
        timePickerSeconds: true,
        locale: {
            format: 'HH:mm:ss'
        }
    }).on('show.daterangepicker', function (ev, picker) {
        picker.container.find(".calendar-table").hide();
    });

    //all-week-js

    $('.all-week-js').on('click', function () {

        var val = this.checked;

        $.each($('.week-js'), function (index, value) {
            value.checked = val;
        });

    });

    $('.week-js').on('click', function () {

        if (this.checked === false) {
            $('.all-week-js')[0].checked = false;
        }

        if ($('.week-js:checked').length === 7) {
            $('.all-week-js')[0].checked = true;
        }
    });

    //gender
    $('.all-gender-js').on('click', function () {
        if (this.checked) {
            $.each($('.gender-js'), function (index, value) {
                value.checked = false;
            });
        }
    });

    $('.gender-js').on('click', function () {
        if (this.checked) {
            $.each($('.all-gender-js'), function (index, value) {
                value.checked = false;
            });
        }
    });

    //platform
    $('.all-platform-js').on('click', function () {
        if (this.checked) {
            $.each($('.platform-js'), function (index, value) {
                value.checked = false;
            });
        }
    });

    $('.platform-js').on('click', function () {
        if (this.checked) {
            $.each($('.all-platform-js'), function (index, value) {
                value.checked = false;
            });
        }
    });
    //Status
    $('.all-status-js').on('click', function () {
        if (this.checked) {
            $.each($('.status-js'), function (index, value) {
                value.checked = false;
            });
        }
    });

    $('.status-js').on('click', function () {
        if (this.checked) {
            $.each($('.all-status-js'), function (index, value) {
                value.checked = false;
            });
        }
    });

    $('.change-campaign-status-js').on('click', function () {

        var newStatus = $(this).data('id');
    });
});