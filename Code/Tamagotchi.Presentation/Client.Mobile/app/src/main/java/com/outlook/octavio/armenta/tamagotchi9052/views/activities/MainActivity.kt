package com.outlook.octavio.armenta.tamagotchi9052.views.activities

import android.os.Bundle
import android.support.design.widget.NavigationView
import android.support.v4.view.GravityCompat
import android.support.v7.app.ActionBarDrawerToggle
import android.support.v7.app.AppCompatActivity
import android.view.MenuItem
import android.widget.Toast
import com.outlook.octavio.armenta.tamagotchi9052.views.fragments.PetFragment
import com.outlook.octavio.armenta.tamagotchi9052.R
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.app_bar_main.*

class MainActivity : AppCompatActivity(), NavigationView.OnNavigationItemSelectedListener  {


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        setSupportActionBar(toolbar)

        val toggle = ActionBarDrawerToggle(
               this, drawer_layout, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close)
        drawer_layout.addDrawerListener(toggle)
        toggle.syncState()

        // Begin the transaction
        val ft = supportFragmentManager.beginTransaction()
        // Replace the contents of the container with the new fragment
        ft.replace(R.id.placeholder_frame_fragment, PetFragment())
        // or ft.add(R.id.your_placeholder, new FooFragment());
        // Complete the changes added above
        ft.commit()

        nav_view.setNavigationItemSelectedListener(this)
    }


    override fun onNavigationItemSelected(item: MenuItem): Boolean {
        when (item.itemId) {
            R.id.nav_first_fragment -> {
                Toast.makeText(this, "PET ONE", Toast.LENGTH_LONG).show()
            }
            R.id.nav_second_fragment -> {
                Toast.makeText(this, "PET TWO", Toast.LENGTH_LONG).show()
            }
            R.id.nav_third_fragment -> {
                Toast.makeText(this, "PET THREE", Toast.LENGTH_LONG).show()
            }
            R.id.nav_fourth_fragment -> {
                Toast.makeText(this, "PET FOURTH", Toast.LENGTH_LONG).show()
            }
            R.id.nav_send -> {
                Toast.makeText(this, "OPEN STORE", Toast.LENGTH_LONG).show()
            }
        }

        drawer_layout.closeDrawer(GravityCompat.START)
        return true
    }
}