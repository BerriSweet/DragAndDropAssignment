using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Views;
using Android.Graphics;
using Android.Media;
using System;
using Android.Content.Res;
using Android.Util;
using Android.Content;

namespace DragDropListviewDroid
{
    [Activity(Label = "DragDropListviewDroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        List<string> items;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            var list = FindViewById<DraggableListView>(Resource.Id.draggableListView1);
            items = new List<string> {
                "galaxias",
                "warning",
                "self_control",
                "together_we_ride",
                "great_distance",
                "sand_planets",
                "click_clock_wood",
            };
            list.Adapter = new DraggableListAdapter(this, items);
            list.ItemClick += List_ItemClick;
            Log.Warn("WARNING TAG", "WARNING STRING");
            Log.Info("INFO TAG", "INFO STRING");
            Log.Error("ERROR TAG", "ERROR STRING");
        }

        MediaPlayer player;

        private void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (player == null)
            {
                player = new MediaPlayer();
            }
            else
            {
                string filename = items[e.Position] + ".mp3";
                player.Stop();
                player.Release();
                StartPlayer(filename);
            }
        }

        public void StartPlayer(String filePath)
        {
            
            string file = filePath;

            switch (file)
            {
                case "galaxias.mp3":
                    player = MediaPlayer.Create(this, Resource.Raw.galaxias);
                    player.Start();
                    break;
                case "warning.mp3":
                    player = MediaPlayer.Create(this, Resource.Raw.warning);
                    player.Start();
                    break;
                case "self_control.mp3":
                    player = MediaPlayer.Create(this, Resource.Raw.self_control);
                    player.Start();
                    break;
                case "together_we_ride.mp3":
                    player = MediaPlayer.Create(this, Resource.Raw.together_we_ride);
                    player.Start();
                    break;
                case "great_distance.mp3":
                    player = MediaPlayer.Create(this, Resource.Raw.great_distance);
                    player.Start();
                    break;
                case "sand_planets.mp3":
                    player = MediaPlayer.Create(this, Resource.Raw.sand_planet);
                    player.Start();
                    break;
                case "click_clock_wood.mp3":
                    player = MediaPlayer.Create(this, Resource.Raw.click_clock_wood);
                    player.Start();
                    break;
            }
            
        }

    }

        public class DraggableListAdapter : BaseAdapter, IDraggableListAdapter
        {
            public List<string> Items { get; set; }


            public int mMobileCellPosition { get; set; }

            Activity context;

            public DraggableListAdapter(Activity context, List<string> items) : base()
            {
                Items = items;
                this.context = context;
                mMobileCellPosition = int.MinValue;
            }

            public override Java.Lang.Object GetItem(int position)
            {
                return Items[position];
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View cell = convertView;
                if (cell == null)
                {
                    cell = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, parent, false);
                    cell.SetMinimumHeight(150);
                    cell.SetBackgroundColor(Color.BlueViolet);
                }

                var text = cell.FindViewById<TextView>(Android.Resource.Id.Text1);
                if (text != null)
                {
                    //text.Text = position.ToString();
                    text.Text = Items[position]; // I changed this line to show the item values in the list
                }

                cell.Visibility = mMobileCellPosition == position ? ViewStates.Invisible : ViewStates.Visible;
                cell.TranslationY = 0;

                return cell;
            }

            public override int Count
            {
                get
                {
                    return Items.Count;
                }
            }

            public void SwapItems(int indexOne, int indexTwo)
            {
                var oldValue = Items[indexOne];
                Items[indexOne] = Items[indexTwo];
                Items[indexTwo] = oldValue;
                mMobileCellPosition = indexTwo;
                NotifyDataSetChanged();
            }

        }

    }

