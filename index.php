 <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style type="text/css">
  .borde{
    font-size: 20px;
    border: 2px solid lightblue;
    border-radius: 5px;
    padding: 10px;
    margin-right: 5px;
  }
</style>

   <div class="container">
	<center> 
      <h1 class="my-4 text-center text-lg-left">Riku</h1>
      <h6>V1.0</h6>
      <br/>
      <br/>
      <br/>
      <div class="container"><a href="index.php"><button class="btn btn-primary"><i class="fa fa-home"></i> Inicio</button></a>
      <a href="contacto.php"><button class="btn btn-primary"><i class="fa fa-phone"></i> Contato</button></a></div>
      <br>
      <hr>
<div class="">
 <div class="text-center text-lg-left">
 <br>
 <br>
 <br>
        <?php
            $files = scandir("posts");
            foreach ($files as $file){
              $ruta = "posts/{$file}";
              if (is_file($ruta)) {   
                $txt = str_replace('.html','',$file);
                echo "<div class='borde col-lg-3 col-md-4 col-xs-6'>
                  <a href='post.php?f={$file}' class='d-block mb-4 h-0'>
                    $txt
                  </a>
                </div>";
              }

            }
         ?>
      </div>
</div>
</center>
  </div>