package com.outlook.octavio.armenta;

import com.outlook.octavio.armenta.viewmodels.HelloWorldViewModel;
import com.outlook.octavio.armenta.views.HelloWorldView;
import de.saxsys.mvvmfx.FluentViewLoader;
import de.saxsys.mvvmfx.ViewTuple;
import javafx.application.Application;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.image.Image;
import javafx.stage.Stage;

public class App extends Application {
    public static void main(String...args){
        Application.launch(args);
    }

    @Override
    public void start(Stage stage){
        stage.setTitle("Tamagotchi - Developer Edition 2018 ®");
        stage.getIcons().add(new Image("faviconpng.png"));

        ViewTuple<HelloWorldView, HelloWorldViewModel> viewTuple = FluentViewLoader.fxmlView(HelloWorldView.class).load();

        Parent root = viewTuple.getView();
        stage.setScene(new Scene(root));

        stage.setMinHeight(720);
        stage.setMinWidth(1280);

        stage.show();
    }
}
