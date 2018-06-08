package com.outlook.octavio.armenta.tamamotchi.Views

import android.os.Bundle
import android.app.Activity
import android.content.Intent
import android.content.Loader
import android.database.Cursor
import android.support.design.widget.NavigationView
import android.support.v4.view.GravityCompat
import android.support.v4.widget.DrawerLayout
import android.support.v7.app.ActionBarDrawerToggle
import android.support.v7.app.AppCompatActivity
import android.view.MenuItem
import com.outlook.octavio.armenta.tamamotchi.R
import kotlinx.android.synthetic.main.activity_pet.*
import kotlinx.android.synthetic.main.app_bar_pet.*

class StoreActivity : AppCompatActivity(), NavigationView.OnNavigationItemSelectedListener {


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_store)
        }

    override fun onNavigationItemSelected(item: MenuItem): Boolean {
        // Handle navigation view item clicks here.
        when (item.itemId) {
            R.id.list_item_pet -> {
                // Handle the camera action
                startActivity(Intent(baseContext, PetActivity::class.java))
            }
            R.id.nav_send -> {

            }
        }

        drawer_layout.closeDrawer(GravityCompat.START)
        return true
    }
}