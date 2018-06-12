package com.outlook.octavio.armenta.tamagotchi9052.activities


import android.os.Bundle
import android.support.v7.app.AppCompatActivity
import com.outlook.octavio.armenta.tamagotchi9052.fragments.AccessMethodFragment
import com.outlook.octavio.armenta.tamagotchi9052.R

class EntryActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_entry)

        val ft = supportFragmentManager.beginTransaction()
        // Replace the contents of the container with the new fragment
        ft.replace(R.id.login_or_register_fragment, AccessMethodFragment())
        // or ft.add(R.id.your_placeholder, new FooFragment());
        // Complete the changes added above
        ft.commit()

    }
}
