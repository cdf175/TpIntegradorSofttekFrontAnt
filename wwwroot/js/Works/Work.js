var token = getCookie("Token");

let table = new DataTable('#works', {
    ajax: {
        url: `https://localhost:7238/api/work`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'id', title: 'Id' },
        { data: 'date', title: 'Fecha' },
        { data: 'hourQuantity', title: 'Cantidad de horas' },
        { data: 'hourValue', title: 'Valor hora' },
        { data: 'cost', title: 'Total' },
        {
            data: function (data) {              
                return `<td><a href='javascript:editWork(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square "></i></td>`;
            }
        },
        {
            data: function (data) {
                return `<td><a href='javascript:deleteWork(${JSON.stringify(data)})'><i class="fa-solid fa-trash "></i></td>`;
            }
        }

    ]
});
