var InitiateSimpleDataTable = function () {
    
    return {
        init: function (tableID, colArray, exportcolnumber) {
            var dataTable = $(tableID)
                //.on('page.dt', function () { $("img.lazy").lazyload(); alert('hi'); })
                .DataTable({
                    "bPaginate": true,
                    "bAutoWidth": false,
                    "iDisplayLength": 5,
                    "aLengthMenu": [
                        [5, 15, 20, 100, -1],
                        [5, 15, 20, 100, "All"]
                    ],
                    "dom": "<'fc-clear col-sm-5 col-xs-12 col-md-3 col-lg-2 clearfix min-width-230'f><'col-md-8 col-sm-7 col-xs-12'Bl>t<'row DTTTFooter'<'col-sm-6'i><'col-sm-6'p>>",
                    buttons: [
                        {
                            extend: 'print',
                            exportOptions: {
                                columns: exportcolnumber
                            }
                        },
                        {
                            extend: 'collection',
                            text: 'Export <i class=\"fa fa-angle-down\"></i>',
                            background: false,
                            buttons: [

                                {
                                    text: 'Csv',
                                    extend: 'csv',
                                    background: false,
                                    exportOptions: {
                                        columns: exportcolnumber
                                    }
                                },
                                {
                                    text: 'Excel',
                                    extend: 'excelHtml5',
                                    background: false,
                                    exportOptions: {
                                        columns: exportcolnumber
                                    }
                                },
                                {
                                    text: 'Pdf',
                                    extend: 'pdf',
                                    background: false,
                                    exportOptions: {
                                        columns: exportcolnumber
                                    }
                                },
                            ]
                        }

                    ],
                    columns: colArray,
                    responsive: true,
                    order: [[0, 'asc']],
                    deferRender: true,
                    drawCallback: function () {
                        $("img.lazy").lazyload();
                        setTimeout(function () {
                            $(window).trigger("scroll")
                        }, 1000);
                    }
                });
        }
    };

}();