$(document).ready(function () {
   loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tbl').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            {data:'id',"width":"5%"},
            {data:'title',"width":"10%"},
            { data: 'description', "width": "15%" },
            { data: 'isbn', "width": "10%" },
            { data: 'author', "width": "15%" },
            { data: 'listPrice', "width": "15%" },
            { data: 'categories.name', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group"> 
                                <a href="/Admin/Product/Edit?id=${data}" class="btn btn-outline-primary mx-2"><i class="bi bi-pencil-square "></i>Ürünü Düzenle</a>
                                <a href="/Admin/Product/Delete?id=${data}" class="btn btn-outline-danger mx-2"><i class="bi bi-pencil-square "></i>Ürünü Kaldır</a>
                            </div>`
                },
                "width":"20%"
            }
            

        ]
    });
    
    
  
}