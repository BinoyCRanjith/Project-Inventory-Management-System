var InitiateSimpleDataTable = function () {
    return {
        init: function (tableID, colArray) {
            var dataTable = $(tableID).DataTable({
                "bAutoWidth": false,
                "iDisplayLength": 5,
                "aLengthMenu": [
                  [5, 15, 20, 100, -1],
                  [5, 15, 20, 100, "All"]
                ],
                "dom": "<'fc-clear col-sm-12 col-md-6 col-lg-6 pull-left'f><'col-sm-12 col-md-6 col-lg-6'Bl>t<'row DTTTFooter'<'col-sm-6'i><'col-sm-6'p>>",
                buttons: [
                       'print',
                       {
                           extend: 'collection',
                           background: false,
                           text: 'Export <i class=\"fa fa-angle-down\"></i>',
                           buttons: ['csv', 'excel', 'pdf'],
                           exportOptions: {
                               columns: ':visible'
                           },
                       },
                ],
                columns: colArray,
                responsive: true,
                order: [[0, 'asc']]
            });

        }
    };

}();