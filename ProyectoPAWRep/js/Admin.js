$('a[data-icon="collapse"]').click(function(event) {
    object_clicked = $("#"+event.currentTarget.id);
    if (object_clicked.children("i").hasClass('fas fa-chevron-right')) {
        object_clicked.children("i").removeClass('fas fa-chevron-right');
        object_clicked.children("i").addClass('fas fa-chevron-down');
    }else{
        object_clicked.children("i").removeClass('fas fa-chevron-down');
        object_clicked.children("i").addClass('fas fa-chevron-right');        
    }
});

$('.colapse-button').click(function(event) {
    if ($('.colapse-button').data( "collapsed-navbar" ) == "collapse") {
        $('.colapse-button').children("i").removeClass('fas fa-chevron-left');
        $('.colapse-button').children("i").addClass('fas fa-chevron-right');
        $("#sidebar").removeClass("d-block");
        $("#sidebar").addClass("d-none");
        $('.colapse-button').data("collapsed-navbar", "collapsed");
    }else{
        $('.colapse-button').children("i").removeClass('fas fa-chevron-right');
        $('.colapse-button').children("i").addClass('fas fa-chevron-left');
        $("#sidebar").removeClass("d-none");
        $("#sidebar").addClass("d-block"); 
        $('.colapse-button').data("collapsed-navbar", "collapse");     
    }
});