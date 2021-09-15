var InitiateSimpleDataTable = function () {
    return {
        init: function (tableID,colArray) {
            var dataTable = $(tableID).DataTable({
                "bAutoWidth": false,
                "iDisplayLength": 20,
                "aLengthMenu": [
                  [20,50, 100, -1],
                  [20,50, 100, "All"]
                ],
                "dom": "<'col-sm-6'f><'col-sm-6'Bl>t<'row DTTTFooter'<'col-sm-6'i><'col-sm-6'p>>",
                buttons: [
                       'print',
                       {
                           extend: 'collection',
                           background: false,
                           text: 'Export <i class=\"fa fa-angle-down\"></i>',
                           buttons: ['csv', 'excel', 'pdf']
                       }
                ],
                columns: colArray,
                responsive: true
            });

        }
    };

}();