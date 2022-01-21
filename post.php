<?php
 $tmp = $_GET['f'];
    $foto = "posts/{$tmp}";
    if (!is_file($foto)) {
      header("location:./");
    }else{
    	echo "<script>window.location = 'posts/{$tmp}';</script>";
    }

?>