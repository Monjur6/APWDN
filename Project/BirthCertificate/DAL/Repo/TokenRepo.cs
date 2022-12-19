using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{

    public class TokenRepo : IRepositoryy<Token, string>
    {
        BIRTHEntities db;

        public TokenRepo(BIRTHEntities db)
        {
            this.db = db;
        }

        public void Add(Token e)
        {
            this.db.Tokens.Add(e);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var token = db.Tokens.FirstOrDefault(c => c.tokenaccess == id);
            db.Tokens.Remove(token);
            db.SaveChanges();
        }

        public void Edit(Token e)
        {
            var t = db.Tokens.FirstOrDefault(en => en.id == e.id);
            db.Entry(t).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(string id)
        {
            return db.Tokens.FirstOrDefault(c => c.tokenaccess == id);
        }
    }
}