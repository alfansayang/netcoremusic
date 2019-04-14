$(document).ready(function () {


    loaddata();

    $('#modalAdd').on(' .bs.modal', function (event) {
        //cleart input hidden artist ID
        $('#ArtistID').val('');
        //$("#btnCreate").removeClass('d-none');
        //$("#btnSave").addClass('d-none');
        //$(this).find('form')[0].reset();
    })


    //clear all inputs within form
    $('#modalAdd').on('hidden.bs.modal', function () {
        $(this).find('form')[0].reset();
    });

    //stop music when modal already closed
    $('#modalplaymusic').on('hidden.bs.modal', function () {
        $('#divimgalbum').empty();
        $('#musicplayer').attr('src', '')
        //$('#divmusicplayer').empty();
    });


    $(function () {
        $('#formmusic').submit(function () {
            if ($(this).valid()) {
                insertData();
            }
        });
    });

    audiojs.events.ready(function () {
        var as = audiojs.createAll();
    });

});
var table;
var loaddata = function () {
    $.ajax({
        type: "GET",
        url: "/api/artist/GetArtists",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (index) {
                //$("#selectCoa").append($('<option>', { value: data[index].COA, text: data[index].COA }));
                var htmlString = '';
                htmlString += '<tr>';
                htmlString += '<td></td>';
                //htmlString += '<td>' + '<img src="' + data[index].imageUrl + '" class="img-thumbnail"><p>' + data[index].albumName + '</p>' + '</td>';
                htmlString += '<td>' + '<img src="' + data[index].imageUrl + '" class="rounded mx-auto d-block"><p>' + data[index].albumName + '</p>' + '</td>';
                htmlString += '<td>' + data[index].artistName + '</td>';
                htmlString += '<td>' + GetDateFormatter(data[index].releaseDate) + '</td>';
                htmlString += '<td><button type="button" class="btn btn-primary btnplay btn-sm" value="' + data[index].artistId + '" onclick="PlayMusic(' + data[index].artistId + ')">Play</button></td>';
                htmlString += '<td>' + data[index].price + '</td>';
                htmlString += '<td><button type="button" class="btn btn-info btn-sm" onclick="Edit(' + data[index].artistId + ')">Edit</button> <button type="button" class="btn btn-danger btn-sm" onclick="Delete(' + data[index].artistId +  ')">Delete</button ></td >'; 
                htmlString += '</tr>';
                $('#tblmusic tbody').append(htmlString);
            });

            table = $('#tblmusic').DataTable({
                "searching": false,
                "bDestroy": true,
                "lengthChange": false
            });

            table.on('order.dt search.dt', function () {
                table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                    cell.innerHTML = i + 1;
                });
            }).draw();

        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
}

var insertData = function () {
    if ($('#ArtistID').val() == '') {
        $.ajax({
            type: 'POST',
            url: "/api/artist/Insert",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: JSON.stringify(GetData()),
            success: function (data, textStatus, xhr) {
                //remove row before rebinding data to table grid
                destroyTable();
                //rebinding data
                loaddata();
                console.log(data);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log('Error in Operation');
            }
        });
    } else {
        updateData();
    }
    
};

var updateData = function () {
    var data = GetData();
    data["ArtistID"] = $('#ArtistID').val();
    $.ajax({
        type: 'PUT',
        url: "/api/artist/Update",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: JSON.stringify(data),
        success: function (data, textStatus, xhr) {
            //remove row before rebinding data to table grid
            destroyTable();
            //rebinding data
            loaddata();
            console.log(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation');
        }
    });
}

var Edit = function (id) {
    $('#ArtistID').val(id);
    $.ajax({
        type: "GET",
        url: "/api/artist/GetArtist/" + id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#ArtistName').val(data[0].artistName)
            $('#AlbumName').val(data[0].albumName)
            $('#ImageURL').val(data[0].imageURL)
            $('#ReleaseDate').val(GetDateFormatter(data[0].releaseDate))
            $('#Price').val(data[0].price)
            $('#SampleURL').val(data[0].sampleURL)

            //$("#btnSave").removeClass('d-none');
            //$("#btnCreate").addClass('d-none');
            $('#modalAdd').modal('show');
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
    
}

var Delete = function (id) {
    var answer = confirm('Are you sure want to delete this item ?')
    if (answer) {
        $.ajax({
            url: "/api/artist/Delete/" + id,
            type: "DELETE",
            success: function (result) {
                destroyTable();
                loaddata();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });  
    }
}

var destroyTable = function () {
    table.rows().remove().draw(); //remove all rows in table
    table.destroy(); //remove jquery datatable
}

var PlayMusic = function (id) {    
    $.ajax({
        type: "GET",
        url: "/api/artist/GetArtist/" + id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#lblArtistName').html(data[0].artistName);
            $('#lblAlbumName').html(data[0].albumName);

            var imgAlbumStr = '<img src="' + data[0].imageURL + '" class="img - thumbnail">';
            $('#divimgalbum').append(imgAlbumStr);
            //var playmusic = '<audio src="/mp3/juicy.mp3" preload="auto" />';
            //$('#divmusicplayer').append(playmusic);
            $('#musicplayer').attr('src', data[0].sampleURL)

            $('#modalplaymusic').modal('show');
        },
        failure: function (data) {
            alert(data.responseText);
        },
        error: function (data) {
            alert(data.responseText);
        }
    }); 

}

function GetData() {
    var data = {
        //"ArtistID": $('#ArtistID').val(),
        "ArtistName": $('#ArtistName').val(),
        "AlbumName": $('#AlbumName').val(),
        "ImageURL": $('#ImageURL').val(),
        "ReleaseDate": $('#ReleaseDate').val(),
        "Price": $('#Price').val(),
        "SampleURL": $('#SampleURL').val(),
    };
    return data;
}

var GetDateFormatter = function (strDate) {
    var date = new Date(strDate);
    var day,month;
    if ((date.getMonth() + 1) < 10)
        var month = '0' + (date.getMonth() + 1)

    if ((date.getDay() + 1) < 10)
        var day = '0' + (date.getDay() + 1)
    var fullDate = date.getFullYear() + '-' + month + '-' + day;;
    return fullDate;
}