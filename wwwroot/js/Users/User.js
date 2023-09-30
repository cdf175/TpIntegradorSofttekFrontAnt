var token = getCookie("Token");

let table = new DataTable('#users', {
    ajax: {
        url: `https://localhost:7238/api/user`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'id', title: 'Id' },
        { data: 'name', title: 'Nombre' },
        { data: 'dni', title: 'DNI' },
        { data: 'type', title: 'Rol' },
        { data: 'email', title: 'Email' },
        {
            data: function (data) {
                
                
                var botones =
                    `<td><a href='javascript:editUser(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square "></i></td>`
                return botones;
            }
        },
        {
            data: function (data) {
                debugger
                return `<td><a href='javascript:deleteUser(${JSON.stringify(data)})'><i class="fa-solid fa-trash "></i></td>`;
            }
        }

    ]
});


function addUser() {
    $.ajax({
        type: "GET",
        url: "/User/UserAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (result) {
            $('#userAddPartial').html(result);
            $('#userModal').modal('show');
        }

    });
}

function editUser(data) {
    debugger
    $.ajax({
        type: "POST",
        url: "/User/UserAddPartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (result) {
            $('#userAddPartial').html(result);
            $('#userModal').modal('show');
        }

    });
}

function deleteUser(data) {
    debugger
    $.ajax({
        type: "POST",
        url: "/User/UserDeletePartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (result) {
            $('#userDeletePartial').html(result);
            $('#userDModal').modal('show');
        },
        error: function () {}

    });
}