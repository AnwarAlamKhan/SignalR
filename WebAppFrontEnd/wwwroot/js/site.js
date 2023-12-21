// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(() => {
    let connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7060/hub-publisher").build()

    connection.start()

    connection.on("ReceiveSubscriber", function () {
        loadData()
    })

    loadData();

    function loadData() {
        var tr = ''

        $.ajax({
            url: '/Home/DBList',
            method: 'GET',
            success: (result) => {
                arr = $.parseJSON(result);
                $.each(arr, (k, v) => {
                    tr = tr + `<tr>
                        <td>${v.id}</td>
                        <td>${v.subscriberName}</td>
                        <td>${v.recievedData}</td>
                    </tr>`
                })

                $("#tableBody").html(tr)
            },
            error: (error) => {
                console.log(error)
            }
        })
    }
})