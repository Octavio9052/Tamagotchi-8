package com.outlook.octavio.armenta;

import com.outlook.octavio.armenta.viewmodels.MainViewModel;
import com.outlook.octavio.armenta.views.MainView;
import de.saxsys.mvvmfx.FluentViewLoader;
import de.saxsys.mvvmfx.ViewModel;
import de.saxsys.mvvmfx.ViewTuple;
import de.saxsys.mvvmfx.guice.MvvmfxGuiceApplication;
import javafx.application.Application;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.image.Image;
import javafx.stage.Stage;

public class App extends MvvmfxGuiceApplication {
    public static void main(String... args) {
        Application.launch(args);
    }

    public void startMvvmfx(Stage stage) throws Exception {
        stage.setTitle("Tamagotchi - Developer Edition 2018 ®");
        stage.getIcons().add(new Image("com/outlook/octavio/armenta/views/faviconpng.png"));

        ViewTuple<MainView, MainViewModel> viewTuple = FluentViewLoader.fxmlView(MainView.class).load();

        Parent root = viewTuple.getView();
        stage.setScene(new Scene(root));

        stage.show();
    }
}
