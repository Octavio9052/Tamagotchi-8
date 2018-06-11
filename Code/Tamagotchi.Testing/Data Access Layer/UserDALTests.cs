//using system;
//using system.collections.generic;
//using microsoft.visualstudio.testtools.unittesting;
//using tamagotchi.dataaccess.datamodels;
//using tamagotchi.dataaccess.dals;
//using tamagotchi.dataaccess.context;

//namespace tamagotchi.daltesting
//{
//    [testclass]
//    public class userdaltests
//    {


//        [testmethod]
//        public void create()
//        {
//            var context = new tamagotchicontext();
//            var userdal = new userdal(context);
//            var user = new user
//            {
//                name = "octavio armenta",
//                photouri = "http://google.com",
//                animal = { },
//                creations = { },
//                login = new login
//                {
//                    id = 1,
//                    email = "armenta_octavio@hotmail.com",
//                    password = "tumama123"
//                },
//                pets = { },
//                session = { }
//            };
//            var numberofusers = userdal.getall().count;
//            var userr = userdal.create(user);
//            userdal.save();

//            var number = userdal.getall().count;

//            assert.areequal(numberofusers + 1, userdal.getall().count);
//        }


//        [testmethod]
//        public void readsingle()
//        {
//            var userdal = new userdal();

//            var single = userdal.get(17);

//            assert.isnotnull(single);
//        }

//        [testmethod]
//        public void readall()
//        {
//            var userdal = new userdal();

//            var all = userdal.getall();

//            assert.isnotnull(all);
//        }

//        [testmethod]
//        public void update()
//        {
//            var userdal = new userdal();
//            var toupdate = userdal.get(17);
//            var olduser = new user
//            {
//                id = toupdate.id,
//                animal = toupdate.animal,
//                datecreated = toupdate.datecreated,
//                lastmodified = toupdate.lastmodified,
//                login = toupdate.login,
//                loginid = toupdate.loginid,
//                session = toupdate.session,
//                name = toupdate.name,
//                photouri = toupdate.photouri,
//                pets = toupdate.pets,
//                creations = toupdate.creations
//            };

//            toupdate.lastmodified = datetime.now;

//            assert.arenotequal(olduser, toupdate);
//        }

//        [testmethod]
//        public void delete()
//        {
//            var userdal = new userdal();
//            var amount = userdal.getall().count;
//            var allusr = userdal.getall();

//            var list = new list<user>();

//            foreach (var usr in allusr)
//            {
//                list.add(usr);
//            }

//            if (list.capacity > 3)
//            {
//                userdal.delete(list[2].id);
//                assert.areequal(amount - 1, userdal.getall().count);
//            }
//            else
//            {
//                assert.inconclusive();
//            }
//        }
//    }
//}
