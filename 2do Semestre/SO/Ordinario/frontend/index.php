<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <title>Aplicación de Personajes</title>
    <style>
        body { font-family: sans-serif; background: #f4f4f4; display: flex; flex-direction: column; align-items: center; }
        .card { background: white; padding: 20px; margin: 10px; border-radius: 8px; box-shadow: 0 2px 5px rgba(0,0,0,0.1); width: 300px; }
        h1 { color: #333; }
        .category { font-weight: bold; color: #007bff; }
    </style>
</head>
<body>
    <h1>Lista General de Personajes</h1>
    <div id='container'>
        <?php
        $api_url = 'http://api/';
        $response = @file_get_contents($api_url);
        if ($response) {
            $data = json_decode($response, true);
            if (isset($data['records'])) {
                foreach ($data['records'] as $char) {
                    echo "<div class='card'>";
                    echo "<h3>" . htmlspecialchars($char['name']) . "</h3>";
                    echo "<p class='category'>" . htmlspecialchars($char['category']) . "</p>";
                    echo "<p>" . htmlspecialchars($char['description']) . "</p>";
                    echo "</div>";
                }
            }
        } else { echo '<p>Error al conectar con la API.</p>'; }
        ?>
    </div>
</body>
</html>
