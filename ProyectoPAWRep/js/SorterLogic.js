$( ".sorter" ).click(function() {
    object_clicked = $(this);
    object_with_sorter = $(".sorter.active");
    if(object_clicked.hasClass('active')){
      switch (object_clicked.data( "sort" )) {
        case 'asc':
          object_clicked.children("i").removeClass('fa fa-sort-numeric-up-alt');
          object_clicked.children("i").addClass('fa fa-sort-numeric-down-alt');
          object_clicked.data( "sort", 'desc');
          break;
        case 'desc':
          object_clicked.children("i").removeClass('fa fa-sort-numeric-down-alt');
          object_clicked.children("i").addClass('fa fa-sort-numeric-up-alt');
          object_clicked.data("sort", 'asc');
          break;
      }
    }else{
    object_with_sorter.removeData("sort");
      object_with_sorter.removeClass("active");
      object_with_sorter.children("i").remove();
      
      object_clicked.prepend('<i class="fa fa-sort-numeric-up-alt" aria-hidden="true"></i> ');
      object_clicked.data( "sort", 'asc');
      object_clicked.addClass('active');
    }
  });