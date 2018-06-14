package com.outlook.octavio.armenta.tamagotchi9052.views.activities

import android.os.Bundle
import android.support.design.widget.NavigationView
import android.support.v4.view.GravityCompat
import android.support.v7.app.ActionBarDrawerToggle
import android.support.v7.app.AppCompatActivity
import android.support.v7.widget.LinearLayoutManager
import android.support.v7.widget.RecyclerView
import android.view.MenuItem
import android.widget.Toast
import com.outlook.octavio.armenta.tamagotchi9052.R
import com.outlook.octavio.armenta.tamagotchi9052.models.Animal
import com.outlook.octavio.armenta.tamagotchi9052.views.adapters.StoreAdapter
import kotlinx.android.synthetic.main.activity_store.*
import kotlinx.android.synthetic.main.app_bar_store.*

class StoreActivity : AppCompatActivity(), NavigationView.OnNavigationItemSelectedListener {

    private lateinit var recyclerView: RecyclerView
    private lateinit var viewAdapter: RecyclerView.Adapter<*>
    private lateinit var viewManager: RecyclerView.LayoutManager

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_store)

        val myDataSet = arrayListOf<Animal>()
        val animal = Animal("Fox", "Likes to read and sleep", "http://i.imgur.com/NNfje00.gif")
        val anima2 = Animal("Dog", "Likes to play and eat", "http://i.imgur.com/sumGNLN.gif")
        val anima3 = Animal("Turtle", "Likes to rest and play", "http://i.imgur.com/chU36ua.gif")
        val anima4 = Animal("Cat", "Likes to eat and sleep", "http://i.imgur.com/vRQWS9E.gif")
        myDataSet.add(animal)
        myDataSet.add(anima2)
        myDataSet.add(anima3)
        myDataSet.add(anima4)
        // getAnimalsAvailable

        viewManager = LinearLayoutManager(this)
        viewAdapter = StoreAdapter(myDataSet)

        recyclerView = findViewById<RecyclerView>(R.id.my_recycler_view).apply {
            // use this setting to improve performance if you know that changes
            // in content do not change the layout size of the RecyclerView
            setHasFixedSize(true)

            // use a linear layout manager
            layoutManager = viewManager

            // specify an viewAdapter (see also next example)
            adapter = viewAdapter
        }

        setSupportActionBar(toolbar_store)

        val toggle = ActionBarDrawerToggle(
                this, drawer_layout_store, toolbar_store, R.string.navigation_drawer_open, R.string.navigation_drawer_close)
        drawer_layout_store.addDrawerListener(toggle)
        toggle.syncState()

        nav_view_store.setNavigationItemSelectedListener(this)
    }


    override fun onNavigationItemSelected(item: MenuItem): Boolean {
        when (item.itemId) {
            R.id.nav_first_fragment -> {
                startActivity(intent.setClass(this, MainActivity::class.java))
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

        drawer_layout_store.closeDrawer(GravityCompat.START)
        return true
    }

}
