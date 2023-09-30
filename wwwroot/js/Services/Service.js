var token = getCookie("Token");

let table = new DataTable('#services', {
    ajax: {
        url: `https://localhost:7238/api/service`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'id', title: 'Id' },
        { data: 'description', title: 'Descripcion' },
        { data: 'state', title: 'Activo' },
        { data: 'hourValue', title: 'Valor Hora' },
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
