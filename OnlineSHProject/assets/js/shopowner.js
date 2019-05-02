$(document).ready(function(){  

    $('.add-tag').on('keyup', function (event) {
        var keyboardKey = event.keyCode || event.which;
        if (keyboardKey === 188) {
          var thisValue = $(this).val().slice(0, -1);
          $(this).parent('td').children('.tags').append('<span class="tag-span">' + thisValue + '<i class="fas fa-times"></i></span>');
          $(this).val('');
        }
      });

      $('.tags').on('click', '.tag-span i', function () {
        $(this).parents('.tag-span').remove(); 
      });

    var i=1;  
    $('#add').click(function(){  
         i++;  
         $('#dynamic_field').append('<tr id="row'+i+'"><td><input type="text" name="name[]" placeholder="Enter attribute" class="form-control name_list" /> <input type="text" placeholder="Enter value then press comma [ , ]" class="form-control add-tag" /><div class="tags values_list"></div></td><td><button type="button" name="remove" id="'+i+'" class="btn btn-danger btn_remove">X</button></td></tr>');
         
         $('.add-tag').on('keyup', function (event) {
            var keyboardKey = event.keyCode || event.which;
            if (keyboardKey === 188) {
              var thisValue = $(this).val().slice(0, -1);
              $(this).parent('td').children('.tags').append('<span class="tag-span">' + thisValue + '<i class="fas fa-times"></i></span>');
              $(this).val('');
            }
          });

          $('.tags').on('click', '.tag-span i', function () {
            $(this).parents('.tag-span').remove();
          });
         
    });  

    $(document).on('click', '.btn_remove', function(){  
         var button_id = $(this).attr("id");   
         $('#row'+button_id+'').remove();  
    });  

    $('#submit').click(function(){            
         $.ajax({  
              url:"name.php",  
              method:"POST",  
              data:$('#add_name').serialize(),  
              success:function(data)  
              {  
                   alert(data);  
                   $('#add_name')[0].reset();  
              }  
         });  
    });  

    $('#v-pills-manage-products').on('click', '.hide', function () {
        $(this).parents('tr').hide(); 
    });

});  