using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Core.Service.Concrete;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Repository.Interface;
using BHA.ManagementAssistant.Nutritious.Service.Interface;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Service.Concrete
{
    public class MenuElementService : EntityService<MenuElement>, IMenuElementService
    {
        private IUserRepository _repositoryUser;
        private IOrganizationRepository _repositoryOrganization;
        private IRepository<OrganizationMenuTypeRelation> _repositoryOrganizationMenuTypeRelation;
        private IRepository<UserMenuTypeRelation> _repositoryUserMenuTypeRelation;
        public MenuElementService(IRepository<MenuElement> repositoryMenuElement, IUserRepository repositoryUser, IOrganizationRepository repositoryOrganization, IRepository<OrganizationMenuTypeRelation> repositoryOrganizationMenuTypeRelation, IRepository<UserMenuTypeRelation> repositoryMenuTypeRelation) : base(repositoryMenuElement)
        {
            _repositoryUser = repositoryUser;
            _repositoryOrganizationMenuTypeRelation = repositoryOrganizationMenuTypeRelation;
            _repositoryUserMenuTypeRelation = repositoryMenuTypeRelation;
            _repositoryOrganization = repositoryOrganization;
        }

        public IQueryable<MenuElement> GetMenuElement()
        {
            IQueryable<OrganizationMenuTypeRelation> queryOrganizationMenuTypeRelation = this._repositoryOrganizationMenuTypeRelation.ForJoin();
            IQueryable<UserMenuTypeRelation> queryUserMenuTypeRelation = this._repositoryUserMenuTypeRelation.ForJoin();
            IQueryable<MenuElement> queryMenuElement = this.Repository.ForJoin();

            int currentOrganizationID = _repositoryOrganization.GetCurrentOrganizationID();
            int currentUserID = _repositoryUser.GetCurrentUserID();

            IQueryable<MenuElement> query = from omtr in queryOrganizationMenuTypeRelation
                                            join umtr in queryUserMenuTypeRelation on omtr.MenuTypeEnum equals umtr.MenuTypeEnum
                                            join menuElement in queryMenuElement on umtr.MenuTypeEnum equals menuElement.MenuTypeEnum
                                            where umtr.UserID == currentUserID && omtr.OrganizationID == currentOrganizationID
                                            select menuElement;

            return query;
        }
    }
}