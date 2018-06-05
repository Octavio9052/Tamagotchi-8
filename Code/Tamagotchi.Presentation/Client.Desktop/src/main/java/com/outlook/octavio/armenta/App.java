package com.outlook.octavio.armenta;

import javafx.application.Application;
import javafx.stage.Stage;

public class App extends Application {
    public static void main(String... args) {
        Application.launch(args);
    }

    @Override
    public void start(Stage stage) {
        stage.setTitle("Hello World Application");
        stage.show();
    }
}
