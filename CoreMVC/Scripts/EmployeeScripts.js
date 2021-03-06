﻿
$(document).ready(function () {

    $('#employee_form').on('shown.bs.modal', function () {
        $('#myInput').trigger('focus')
    });

/*Getting Employee Details*/

    $.ajax({ method: 'GET', url: '/Home/GetEmployees' }).done(function (response) {
        var arr = JSON.parse(response);
        $.ajax({ method: 'GET', url: '/Home/GetDesignations' }).done(function (desresponse) {
            var desarr = JSON.parse(desresponse);
            for (var i = 0; i < arr.length; i++) {
                var thisdes = '';
                for (var j = 0; j < desarr.length; j++) {
                    if (desarr[j].id == arr[i].designation)
                        thisdes = desarr[j].name;
                }
                var newrow = '<tr><td class="td" id="id' + arr[i].id + '">' + arr[i].id + '</td><td class="td" id="name' + arr[i].id + '">' + arr[i].first_name + ' ' + arr[i].last_name + '</td><td class="tdd" id="desg' + arr[i].id + '">' + thisdes + '</td><td class="td" id="des' + arr[i].id + '">' + arr[i].joining_date + '</td>';
                newrow += '<td><button type="button" class="btn btn-primary btn-sm" onclick="update_employee(' + arr[i].id + ')"><span class="glyphicon glyphicon-pencil" ></span ></button >';
                newrow += '<button type="button" class="btn btn-danger btn-sm" onclick="delete_employee(' + arr[i].id + ')"><span class="glyphicon glyphicon-trash" ></span ></button ></td ></tr > ';
                $('#employee_table').append(newrow);
            }
        });
    });

/* Add Button*/

    $('#add_employee').click(function () {
        $.ajax({ method: 'GET', url: '/Home/GetDesignations' }).done(function (response) {
            var arr = JSON.parse(response);
            while (document.getElementById('designation').firstChild)
                document.getElementById('designation').removeChild(document.getElementById('designation').firstChild);
            for (var i = 0; i < arr.length; i++) {
                document.getElementById('designation').add(new Option(arr[i].name, arr[i].id));
            }
        });
        $('#employee_form').show();

    });

/* Close Buttons*/

    $('#close_form').click(function () {
        $('#first_name').val('');
        $('#last_name').val('');
        $('#employee_form').hide();
    });
    $('#close_update_form').click(function () {
        $('#update_first_name').val('');
        $('#update_last_name').val('');
        $('#update_form').hide();
    });

    /* Add Employee */

    $('#submit').click(function () {
        var submit_data = {
            "id": "12",
            "first_name": $('#first_name').val(),
            "last_name": $('#last_name').val(),
            "designation": $('#designation').val(),
            "joining_date": $('#joining_date').val(),
        };
        console.log(JSON.stringify(submit_data));
        $.ajax({ method: 'POST', url: '/Home/AddEmployee', data: submit_data }).done(function (response) {
            console.log(response);
            $('#first_name').val('');
            $('#last_name').val('');
            $('#employee_form').hide();
            $('#employee_table').html('<thead><tr class="tr"><th>ID</th><th>Name</th><th>Designation</th><th>Date of Joining</th><th></th></tr></thead >');
            $.ajax({ method: 'GET', url: '/Home/GetEmployees' }).done(function (response) {
                var arr = JSON.parse(response);
                $.ajax({ method: 'GET', url: '/Home/GetDesignations' }).done(function (desresponse) {
                    var desarr = JSON.parse(desresponse);
                    for (var i = 0; i < arr.length; i++) {
                        var thisdes = '';
                        for (var j = 0; j < desarr.length; j++) {
                            if (desarr[j].id == arr[i].designation)
                                thisdes = desarr[j].name;
                        }
                        var newrow = '<tr><td class="td" id="id' + arr[i].id + '">' + arr[i].id + '</td><td class="td" id="name' + arr[i].id + '">' + arr[i].first_name + ' ' + arr[i].last_name + '</td><td class="tdd" id="desg' + arr[i].id + '">' + thisdes + '</td><td class="td" id="des' + arr[i].id + '">' + arr[i].joining_date + '</td>';
                        newrow += '<td><button type="button" class="btn btn-primary btn-sm" onclick="update_employee(' + arr[i].id + ')"><span class="glyphicon glyphicon-pencil" ></span ></button >';
                        newrow += '<button type="button" class="btn btn-danger btn-sm" onclick="delete_employee(' + arr[i].id + ')"><span class="glyphicon glyphicon-trash" ></span ></button ></td ></tr > ';
                        $('#employee_table').append(newrow);
                    }
                });
            });
        }).fail(function () {
            swal("Oops! We faced an error.",
                {

                    icon: "warning",
                    timer: 900,
                    buttons: false
                });
        });
    });

    /* Update Employee */

    $('#update_submit').click(function () {
        var submit_data = {
            "id": $('#update_id').val(),
            "first_name": $('#update_first_name').val(),
            "last_name": $('#update_last_name').val(),
            "designation": $('#update_designation').val(),
            "joining_date": $('#update_joining_date').val(),
        };
        console.log(JSON.stringify(submit_data));
        $.ajax({ method: 'POST', url: '/Home/UpdateEmployee', data: submit_data }).done(function (response) {
            console.log(response);
            $('#first_name').val('');
            $('#last_name').val('');
            $('#update_form').hide();
            $('#employee_table').html('<thead><tr class="tr"><th>ID</th><th>Name</th><th>Designation</th><th>Date of Joining</th><th></th></tr></thead >');
            $.ajax({ method: 'GET', url: '/Home/GetEmployees' }).done(function (response) {
                var arr = JSON.parse(response);
                $.ajax({ method: 'GET', url: '/Home/GetDesignations' }).done(function (desresponse) {
                    var desarr = JSON.parse(desresponse);
                    for (var i = 0; i < arr.length; i++) {
                        var thisdes = '';
                        for (var j = 0; j < desarr.length; j++) {
                            if (desarr[j].id == arr[i].designation)
                                thisdes = desarr[j].name;
                        }
                        var newrow = '<tr><td class="td" id="id' + arr[i].id + '">' + arr[i].id + '</td><td class="td" id="name' + arr[i].id + '">' + arr[i].first_name + ' ' + arr[i].last_name + '</td><td class="tdd" id="desg' + arr[i].id + '">' + thisdes + '</td><td class="td" id="des' + arr[i].id + '">' + arr[i].joining_date + '</td>';
                        newrow += '<td><button type="button" class="btn btn-primary btn-sm" onclick="update_employee(' + arr[i].id + ')"><span class="glyphicon glyphicon-pencil" ></span ></button >';
                        newrow += '<button type="button" class="btn btn-danger btn-sm" onclick="delete_employee(' + arr[i].id + ')"><span class="glyphicon glyphicon-trash" ></span ></button ></td ></tr > ';
                        $('#employee_table').append(newrow);
                    }
                }).fail(function () {
                    swal("Oops! We faced an error.",
                        {

                            icon: "warning",
                            timer: 900,
                            buttons: false
                        });});
            });
        });
    });
});

/* Update Employee */
function update_employee(id) {
    var fnid = '#name' + id;
    var jdid = '#des' + id;
    console.log($(jdid).html());
    var fn = $(fnid).html().split(' ')[0];
    var ln = $(fnid).html().split(' ')[1];
    $('#update_id').val(id);
    $('#update_first_name').val(fn);
    $('#update_last_name').val(ln);
    $('#update_joining_date').val($(jdid).html());
    $.ajax({ method: 'GET', url: '/Home/GetDesignations' }).done(function (response) {
        var arr = JSON.parse(response);
        while (document.getElementById('update_designation').firstChild)
            document.getElementById('update_designation').removeChild(document.getElementById('update_designation').firstChild);
        for (var i = 0; i < arr.length; i++) {
            document.getElementById('update_designation').add(new Option(arr[i].name, arr[i].id));
            if (arr[i].name == $('#desg' + id).html())
                $('#update_designation').val(arr[i].id);
        }
    });
    $('#update_form').show();
}

/* Delete Employee */
function delete_employee(id) {
    var submit_data = {
        "id": id,
        "first_name": "no",
        "last_name": "no",
        "designation": "no",
        "joining_date": "no",
    };
    swal({
        title: "Are you sure you want to delete this record?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({ method: 'POST', url: '/Home/DeleteEmployee', data: submit_data }).done(function (response) {
                    console.log(response);
                    $('#employee_table').html('<thead><tr class="tr"><th>ID</th><th>Name</th><th>Designation</th><th>Date of Joining</th><th></th></tr></thead >');
                    $.ajax({ method: 'GET', url: '/Home/GetEmployees' }).done(function (response) {
                        var arr = JSON.parse(response);
                        $.ajax({ method: 'GET', url: '/Home/GetDesignations' }).done(function (desresponse) {
                            var desarr = JSON.parse(desresponse);
                            for (var i = 0; i < arr.length; i++) {
                                var thisdes = '';
                                for (var j = 0; j < desarr.length; j++) {
                                    if (desarr[j].id == arr[i].designation)
                                        thisdes = desarr[j].name;
                                }
                                var newrow = '<tr><td class="td" id="id' + arr[i].id + '">' + arr[i].id + '</td><td class="td" id="name' + arr[i].id + '">' + arr[i].first_name + ' ' + arr[i].last_name + '</td><td class="tdd" id="desg' + arr[i].id + '">' + thisdes + '</td><td class="td" id="des' + arr[i].id + '">' + arr[i].joining_date + '</td>';
                                newrow += '<td><button type="button" class="btn btn-primary btn-sm" onclick="update_employee(' + arr[i].id + ')"><span class="glyphicon glyphicon-pencil" ></span ></button >';
                                newrow += '<button type="button" class="btn btn-danger btn-sm" onclick="delete_employee(' + arr[i].id + ')"><span class="glyphicon glyphicon-trash" ></span ></button ></td ></tr > ';
                                $('#employee_table').append(newrow);
                            }
                        });
                    });
                });
                swal("Record deleted!", {
                    icon: "success",
                    timer: 900,
                    buttons: false
                });
            } else {
                swal("Record not deleted!",
                    {

                        icon: "info",
                        timer: 900,
                        buttons: false
                    });
            }
        });


}
