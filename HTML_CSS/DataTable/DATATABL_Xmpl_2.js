
    function inittable(data) {
        //console.log(data);
        $('#json_data_table').DataTable({
            "aaData": data
        });
    }

    //$('#json_data_table').dataTable({
        //"aaData": data,
        //"aData": data,
    $.ajax({
        url: "/Home/JsonModel",
        async: false,
        dataType: 'json',
        //columns: [
        //    { "data": "name" },
        //    { "data": "number" },
        //    { "data": "date" },
        //],
        success: function (data) {

            //aData = data;
            //aaData = data;
            //aoData = data;

            var arrayReturn = [];

            for (var i = 0, len = data.length; i < len; i++) {

                console.log('1. ' + data[i].name);
                console.log('2. ' + data[i].number);
                console.log('');

                var desc = data[i];
                arrayReturn.push([data[i].name, data[i].number, data[i].date]);
            }
            inittable(arrayReturn);
        }
    });