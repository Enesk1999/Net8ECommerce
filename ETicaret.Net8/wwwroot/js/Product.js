$(document).ready(function () {
   loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            {data:'id',"width":"5%"},
            {data:'title',"width":"10%"},
            { data: 'description', "width": "15%" },
            { data: 'isbn', "width": "10%" },
            { data: 'author', "width": "15%" },
            { data: 'listPrice', "width": "15%" },
            { data: 'categories.name', "width": "15%" },
            

        ]
    });
    
    
  
}