$(document).ready(function () {
        $("#get").click(getUserNames());
    });


    var getUserNames = function () {
        $("#sampleTable").dataTable({
            "oLanguage": {
                "sZeroRecords": "No records to display",
                "sSearch": "Search on UserName"
            },
            "aLengthMenu": [[25, 50, 100, 150, 250, 500, -1], [25, 50, 100, 150, 250, 500, "All"]],
            "iDisplayLength": 150,
            "bSortClasses": false,
            "bStateSave": false,
            "bPaginate": true,
            "bAutoWidth": false,
            "bProcessing": true,
            "bServerSide": true,
            "bDestroy": true,
            "sAjaxSource": "WebService1.asmx/GetItems",
            "bJQueryUI": true,
            "sPaginationType": "full_numbers",
            "bDeferRender": true,
            "fnServerParams": function (aoData) {

                aoData.push({ "name": "iParticipant", "value": $("#participant").val() });

            },
            "fnServerData": function (sSource, aoData, fnCallback) {
                $.ajax({
                    "dataType": 'json',
                    "contentType": "application/json; charset=utf-8",
                    "type": "GET",
                    "url": sSource,
                    "data": aoData,
                    "success":
                                function (msg) {

                                    var json = jQuery.parseJSON(msg.d);
                                    fnCallback(json);
                                    $("#sampleTable").show();
                                }
                });
            }
        });
    }