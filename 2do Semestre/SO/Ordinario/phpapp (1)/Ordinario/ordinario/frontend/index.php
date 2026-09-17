<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Characters App</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f0f0f0;
            margin: 0;
            padding: 20px;
            display: flex;
            flex-direction: column;
            align-items: center;
        }
        .header {
            background-color: #ff9800;
            color: white;
            padding: 20px;
            width: 100%;
            text-align: center;
            border-radius: 8px;
            margin-bottom: 20px;
            box-shadow: 0 4px 6px rgba(0,0,0,0.1);
        }
        .container {
            display: grid;
            grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
            gap: 20px;
            width: 100%;
            max-width: 1000px;
        }
        .card {
            background-color: white;
            border-radius: 8px;
            padding: 20px;
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
            transition: transform 0.2s;
        }
        .card:hover {
            transform: translateY(-5px);
        }
        .card h3 {
            margin-top: 0;
            color: #ff5722;
            margin-bottom: 15px;
        }
        .badge-container {
            display: flex;
            flex-wrap: wrap;
            gap: 8px;
        }
        .badge {
            background-color: #e3f2fd;
            color: #1976d2;
            padding: 5px 12px;
            border-radius: 16px;
            font-size: 0.85em;
            font-weight: 600;
            border: 1px solid #bbdefb;
        }
        .badge-alt {
            background-color: #f3e5f5;
            color: #7b1fa2;
            border: 1px solid #e1bee7;
        }
        .error {
            color: red;
            background: #ffebee;
            padding: 10px;
            border-radius: 4px;
        }
    </style>
</head>
<body>
    <div class="header">
        <h1>Listado de Elementos</h1>
    </div>

    <div class="container">
        <?php
        // El nombre del servicio backend en docker-compose es 'api'
        $api_url = 'http://api/';

        $response = @file_get_contents($api_url);

        if ($response === FALSE) {
            echo '<p class="error">Error: No se pudo conectar con el Backend (API).</p>';
        } else {
            $data = json_decode($response, true);

            if (isset($data['records']) && count($data['records']) > 0) {
                foreach ($data['records'] as $char) {
                    echo '<div class="card">';
                    echo '<h3>' . htmlspecialchars($char['name']) . '</h3>';
                    
                    if (!empty($char['caracteristica_1']) || !empty($char['caracteristica_2'])) {
                        echo '<div class="badge-container">';
                        if (!empty($char['caracteristica_1'])) {
                            echo '<span class="badge">' . htmlspecialchars($char['caracteristica_1']) . '</span>';
                        }
                        if (!empty($char['caracteristica_2'])) {
                            echo '<span class="badge badge-alt">' . htmlspecialchars($char['caracteristica_2']) . '</span>';
                        }
                        echo '</div>';
                    }
                    
                    echo '</div>';
                }
            } elseif (isset($data['message'])) {
                echo '<p class="error">Aviso del Sistema: ' . htmlspecialchars($data['message']) . '</p>';
            } else {
                echo '<p>No se encontraron elementos en la base de datos.</p>';
            }
        }
        ?>
    </div>
</body>
</html>
