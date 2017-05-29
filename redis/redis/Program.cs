using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace redis
{
	class Program
	{
		public static void Main(string[] args)
		{
			ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect("redis-11030.c1.eu-west-1-3.ec2.cloud.redislabs.com:11030,password=");
			IDatabase conn = muxer.GetDatabase();
			ExecuteCommand(conn);
		}

		private static void ExecuteCommand(IDatabase conn)
		{
			while (true)
			{
				var command = Console.ReadLine();
				if (command.Equals("end"))
				{
					break;
				}
				else
				{
					var parsed = command.Split(' ');
					HandleCommand(conn, parsed);
				}
				
			}
		}

		private static bool HandleCommand(IDatabase conn, string[] command)
		{
			if (command[0] == "add")
			{
				AddParticipant(conn, command[1]);
				return true;
			}
			else if (command[0] == "upvote")
			{
				Upvote(conn, command[1]);
				return true;
			}
			else if (command[0] == "list")
			{
				List(conn);
				return true;
			}
			else if (command[0] == "downvote")
			{
				Downvote(conn, command[1]);
				return true;
			}
			else if (command[0] == "delete")
			{
				Delete(conn, command[1]);
				return true;
			}
			else
			{
				Console.WriteLine("Unknown command");
				return true;
			}
		}

		private static void AddParticipant(IDatabase conn, string name)
		{
			conn.SortedSetAdd("participants", name, 0, When.NotExists);
		}

		private static void Upvote(IDatabase conn, string name)
		{
			conn.SortedSetIncrement("participants", name, 1);
		}

		private static void List(IDatabase conn)
		{
			Array.ForEach(conn.SortedSetRangeByScoreWithScores("participants", order:Order.Descending), item => Console.WriteLine(item));
		}

		private static void Downvote(IDatabase conn, string name)
		{
			conn.SortedSetDecrement("participants", name, 1);
		}

		private static void Delete(IDatabase conn, string name)
		{
			conn.SortedSetRemove("participants", name);
		}
	}
}
