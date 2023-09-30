var token = getCookie("Token");

let table = new DataTable('#proyects', {
    ajax: {
        url: `https://localhost:7238/api/proyect`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'id', title: 'Id' },
        { data: 'name', title: 'Proyecto' },
        { data: 'state', title: 'Estado' },
        { data: 'address', title: 'Direccion' },
        {
            data: function (data) {              
                return `<td><a href='javascript:editService(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square "></i></td>`;
            }
        },
        {
            data: function (data) {
                return `<td><a href='javascript:deleteService(${JSON.stringify(data)})'><i class="fa-solid fa-trash "></i></td>`;
            }
        }

    ]
});
