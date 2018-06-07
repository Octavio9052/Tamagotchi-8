package com.outlook.octavio.armenta.viewmodels;

import de.saxsys.mvvmfx.ViewModel;
import de.saxsys.mvvmfx.utils.commands.Action;
import de.saxsys.mvvmfx.utils.commands.Command;
import de.saxsys.mvvmfx.utils.commands.DelegateCommand;
import javafx.beans.property.*;
import javafx.collections.ObservableMap;
import javafx.scene.image.Image;

import java.io.File;


public class PetDetailsViewModel implements ViewModel {

    public static final String IDLE_BROWSE = "IDLE_BROWSE";
    public static final String PLAY_BROWSE = "PLAY_BROWSE";
    public static final String SLEEP_BROWSE = "SLEEP_BROWSE";
    public static final String EAT_BROWSE = "EAT_BROWSE";
    public static final String PACKAGE_BROWSE = "PACKAGE_BROWSE";

    private ObjectProperty<Image> idleImage = new SimpleObjectProperty<>();
    private ObjectProperty<Image> playImage = new SimpleObjectProperty<>();
    private ObjectProperty<Image> sleepImage = new SimpleObjectProperty<>();
    private ObjectProperty<Image> eatImage = new SimpleObjectProperty<>();

    private ObjectProperty<File> packageProperty = new SimpleObjectProperty<>();

    private StringProperty nameField = new SimpleStringProperty();
    private StringProperty descriptionField = new SimpleStringProperty();
    private StringProperty packageField = new SimpleStringProperty();

    private MapProperty<String, String> dynamicProps;

    private Command idleBrowseCommand;
    private Command playBrowseCommand;
    private Command sleepBrowseCommand;
    private Command eatBrowseCommand;
    private Command packageBrowseCommand;
    private Command addPropCommand;
    private Command createCommand;

    public void initialize() {

        idleBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doIdleBrowse();
            }
        });

        playBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doPlayBrowse();
            }
        });

        sleepBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doSleepBrowse();
            }
        });

        eatBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doEatBrowse();
            }
        });

        packageBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doPackageBrowse();
            }
        });

        addPropCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doAddProp();
            }
        });

        createCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doCreate();
            }
        });


    }

    public void doIdleBrowse() throws Exception {
        publish(IDLE_BROWSE);
    }

    public void doPlayBrowse() {
        publish(PLAY_BROWSE);
    }

    public void doSleepBrowse() {
        publish(SLEEP_BROWSE);
    }

    public void doEatBrowse() {
        publish(EAT_BROWSE);
    }

    public void doPackageBrowse() {
        publish(PACKAGE_BROWSE);
    }

    public void doAddProp() {

    }

    public void doCreate() {
    }


    public Image getIdleImage() {
        return idleImage.get();
    }

    public ObjectProperty<Image> idleImageProperty() {
        return idleImage;
    }

    public Image getPlayImage() {
        return playImage.get();
    }

    public ObjectProperty<Image> playImageProperty() {
        return playImage;
    }

    public Image getSleepImage() {
        return sleepImage.get();
    }

    public ObjectProperty<Image> sleepImageProperty() {
        return sleepImage;
    }

    public Image getEatImage() {
        return eatImage.get();
    }

    public ObjectProperty<Image> eatImageProperty() {
        return eatImage;
    }

    public File getPackageProperty() {
        return packageProperty.get();
    }

    public ObjectProperty<File> packagePropertyProperty() {
        return packageProperty;
    }

    public String getNameField() {
        return nameField.get();
    }

    public StringProperty nameFieldProperty() {
        return nameField;
    }

    public String getDescriptionField() {
        return descriptionField.get();
    }

    public StringProperty descriptionFieldProperty() {
        return descriptionField;
    }

    public String getPackageField() {
        return packageField.get();
    }

    public StringProperty packageFieldProperty() {
        return packageField;
    }

    public ObservableMap<String, String> getDynamicProps() {
        return dynamicProps.get();
    }

    public MapProperty<String, String> dynamicPropsProperty() {
        return dynamicProps;
    }

    public Command getIdleBrowseCommand() {
        return idleBrowseCommand;
    }

    public Command getPlayBrowseCommand() {
        return playBrowseCommand;
    }

    public Command getSleepBrowseCommand() {
        return sleepBrowseCommand;
    }

    public Command getEatBrowseCommand() {
        return eatBrowseCommand;
    }

    public Command getPackageBrowseCommand() {
        return packageBrowseCommand;
    }

    public Command getAddPropCommand() {
        return addPropCommand;
    }

    public Command getCreateCommand() {
        return createCommand;
    }
}
