$('document').ready(function() {

    $('#side-menu').metisMenu();

//Loads the correct sidebar on window load
    $(function() {

        $(window).bind("load", function() {
            console.log($(this).width())
            if ($(this).width() < 753) {
                $('div.sidebar-collapse').addClass('collapse')
            } else {
                $('div.sidebar-collapse').removeClass('collapse')
            }
        })
    })

//Collapses the sidebar on window resize
    $(function() {

        $(window).bind("resize", function() {
            console.log($(this).width())
            if (this.innerWidth < 768) {
                $('div.sidebar-collapse').addClass('collapse')
            } else {
                $('div.sidebar-collapse').removeClass('collapse')
            }
        })  
    });

    var allchecked = false;
    $(".btn-chk").click(function() {
        if (allchecked) {
            allchecked = false;
            $('input:checkbox').prop('checked', 0);
        } else {
            allchecked = true;
            $('input:checkbox').prop('checked', 1);
        }
    });

    // function message success
    $(function () {
        $(".")
            $(".msjadd").hide(2500);
    });
// var myModal = $('#myModal').on('shown', function () {
//     clearTimeout(myModal.data('hideInteval'))
//     var id = setTimeout(function(){
//         myModal.modal('hide');
//     });
//     myModal.data('hideInteval', id);
// });

   $('#myModal').on('hidden.bs.modal',function(e){

   })


   //
window.oncontextmenu= function(){return false;}
document.onkeydown = function(){return false;}
document.onkeydown= function(e){
    if(window.event.keyCode==123||e.button==2 || e.button==17||e.button==42||e.button==47||e.button==85||e.button==43||event.keyCode==17)return false;
}



});



