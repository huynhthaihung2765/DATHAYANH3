
//--------SEARCH
var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#txtKeyword").autocomplete({
            minLength: 0,
            source: function( request, response ) {
                $.ajax({
                    url: "/LinhKien/ListName",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function( res ) {
                        response(res.data);
                    }
                });
            },
            focus: function (event,ui) {
                //$(".txtKeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
               
                window.location.href="/LinhKien/Details/" + ui.item.value + "";
                return false;
            }
        })
     .autocomplete("instance")._renderItem = function (ul, item) {
         return $("<li>")
           .append('<a ><img src="/ImagesProduct/'+item.img+'" alt="" width="32" height="32"/> '+item.label+'</a>')
           .appendTo(ul);
        
     };


    }
}
common.init();
//--------SEARCH







