<script type="text/javascript">
  var index, i, point;
  $('.rateBox img').hover(
    function(){
      index = this.id;
      for(i = 1; i <= index; i++){
        $('#' + i).addClass('fullStar');
      }
    },function(){
      $('.rateBox img').removeClass('fullStar');
    }
  );
  $('.rateBox img').click(function(){
    $('.rateBox img').removeClass('fullStar2');
    point = this.id;
    for(i = 1; i <= index; i++){
      $('#' + i).addClass('fullStar2');
    }
    console.log(point);
    document.getElementById('score').setAttribute("value", point);
  });
</script>